using CoreApp.DataService.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using DTO = CoreApp.Models.DataTransfer;
using VM = CoreApp.Models.ViewModels;

namespace CoreApp.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : EntityBaseApiController<VM.EmployeeViewModel, DTO.Employee>
    {
        public EmployeeController(IEmployeeService entityService, IConfiguration configuration) : base(entityService, configuration)
        {
        }
    }
}