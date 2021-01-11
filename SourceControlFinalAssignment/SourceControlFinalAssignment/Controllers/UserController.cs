using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using log4net;
using SourceControlFinalAssignment.Cryptography;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.Controllers
{
    public class UserController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(UserController));

        // Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        // Registration POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified, ActivationCode")] RegisterUser user, HttpPostedFileBase file)
        {
            // Model Validation
            bool Status = false;
            string message = "";
            // Model Validation
            if (ModelState.IsValid)
            {
                #region Email is already Exist
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                #endregion
                
                user.IsEmailVerified = false;

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                    user.ProfileImage = "~/Images/" + fileName;
                }

                #region Save to Database
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    dc.RegisterUsers.Add(user);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registration successfully done. Account activation link" +
                        " has been sent to your email id:" + user.EmailID;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }
            log.Info("User registration is successfull with " + user.EmailID);
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        //Verify Account
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; // This statement here to avoid 
                                                                // Confirm password does not match issue on save changes
                var v = dc.RegisterUsers.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            string message = "";

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.RegisterUsers.Where(a => a.EmailID == login.EmailID).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        log.Info(login.EmailID + " has logged in.");

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", v);
                        }
                    }
                    else
                    {
                        message = "Invalid creddentials provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.RegisterUsers.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailId, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("pdm2941999@gmail.com", "Prince Makwana");
            var toEmail = new MailAddress(emailId);
            var fromEmailPassword = "Dinesh@29";
            string subject = "Your account is successfully created!!!";

            string body = "<br><br>We are excited to tell you that your account is" +
                " successfully created. Please click on the below link to verify your account" +
                " <a href='" + link + "'>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            
                smtp.Send(message);
            log.Info("User activation code is email is sent to " + toEmail);
        }
    }
}