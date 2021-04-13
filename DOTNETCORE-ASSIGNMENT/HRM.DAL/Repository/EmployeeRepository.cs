using HRM.DAL.Database;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;

namespace HRM.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Add Employee DAL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddEmployee(CreateEmployeeDTO model)
        {
            if(model != null)
            {
                var employee = _mapper.Map<tblEmployees>(model);
                _context.tblEmployee.Add(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete Employee DAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int id)
        {
            var employee = _context.tblEmployee.Find(id);
            if(employee != null)
            {
                _context.tblEmployee.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get List of all Employees DAL
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> getAllemployees()
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

            var employeeEntities = _context.tblEmployee.ToList<tblEmployees>();

            if(employeeEntities != null)
            {
                foreach (var item in employeeEntities)
                {
                    EmployeeDTO employee = _mapper.Map<EmployeeDTO>(item);
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }

        /// <summary>
        /// Get Employee By Id DAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDTO GetEmployeeById(int id)
        {
            var entity = _context.tblEmployee.Find(id);

            if(entity != null)
            {
                EmployeeDTO employee = _mapper.Map<EmployeeDTO>(entity);
                return employee;
            }
            return null;
        }

        /// <summary>
        /// Update Employee DAL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeDTO model)
        {
            if(model != null)
            {
                var entity = _context.tblEmployee.Find(model.ID);
                if(entity != null)
                {
                    //entity = _mapper.Map<tblEmployees>(model);

                    #region Update Employee

                    entity.Name = model.Name;
                    entity.Manager = model.Manager;
                    entity.Phone = model.Phone;
                    entity.isManager = model.isManager;
                    entity.Department = model.Department;
                    entity.Email = model.Email;

                    #endregion

                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
