using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Web.Controllers.Api;
using CoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using DTO = CoreApp.Models.DataTransfer;
using VM = CoreApp.Models.ViewModels;

namespace CoreApp.Web.Controllers
{
    public class HomeController : EntityBaseApiController<VM.EmployeeViewModel, DTO.Employee>
    {
        IEmployeeService _entityService = null;
        IConfiguration _configuration = null;
        public HomeController(IEmployeeService entityService,IConfiguration configuration) : base(entityService, configuration)
        {
            _entityService = entityService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get()
        {
            var v= await GetAll(
                    async entityService => await (entityService as IEmployeeService).ListOfDtoAsync());
            return v;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
