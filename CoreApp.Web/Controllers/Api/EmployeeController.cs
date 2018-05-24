using CoreApp.DataService.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DTO = CoreApp.Models.DataTransfer;
using VM = CoreApp.Models.ViewModels;

namespace CoreApp.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class EmployeeController : EntityBaseApiController<VM.EmployeeViewModel, DTO.Employee>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, IConfiguration configuration) : base(employeeService, configuration)
        {
            _employeeService = employeeService;
        }
    }
}