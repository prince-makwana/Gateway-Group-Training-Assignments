using AutoMapper;
using HRM.DAL.Database;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL
{
    public class AutoMapping : Profile
    {
        /// <summary>
        /// Constructor to instatiniate Automapper Profiles
        /// </summary>
        public AutoMapping()
        {
            CreateMap<tblEmployees, EmployeeDTO>();
            CreateMap<EmployeeDTO, tblEmployees>();
            CreateMap<CreateEmployeeDTO, tblEmployees >();
            CreateMap<EmployeeDTO, tblEmployees>().ForMember(x => x.ID, y => y.Ignore());
        }
    }
}
