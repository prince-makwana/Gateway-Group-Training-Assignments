using HRM.DAL;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRM.BAL.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Add Employee BAL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddEmployee(CreateEmployeeDTO model)
        {
            return _employeeRepository.AddEmployee(model);
        }

        /// <summary>
        /// Delete Employee BAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        /// <summary>
        /// Get List of all Employees BAL
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> getAllemployees()
        {
            return _employeeRepository.getAllemployees();
        }

        /// <summary>
        /// Get Employee By Id BAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        /// <summary>
        /// Update Employee BAL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeDTO model)
        {
            return _employeeRepository.UpdateEmployee(model);
        }
    }
}
