#pragma checksum "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a21e9bad9678e5e0380ee34a1a5deca1eefc44b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Dashboard), @"mvc.1.0.view", @"/Views/Employee/Dashboard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\_ViewImports.cshtml"
using HRM.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\_ViewImports.cshtml"
using HRM.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a21e9bad9678e5e0380ee34a1a5deca1eefc44b4", @"/Views/Employee/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0179b4c50381ba8bfaddb85852ac2d595ae73728", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml"
 if (ViewBag.Message != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        window.onload = function () {\r\n            alert(\"");
#nullable restore
#line 11 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml"
              Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n        };\r\n    </script>\r\n");
#nullable restore
#line 14 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1>Welcome ");
#nullable restore
#line 17 "C:\Users\pdm29\Web Development Projects\Gateway-Group-Training-Assignments\DOTNETCORE-ASSIGNMENT\HRM.MVC\Views\Employee\Dashboard.cshtml"
           Write(HttpContextAccessor.HttpContext.Session.GetString("user"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
