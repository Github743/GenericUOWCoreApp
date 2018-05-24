using CoreApp.DataProvider;
using CoreApp.DataService.Abstraction;
using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Models.Models;
using Microsoft.Extensions.Configuration;
using DTO = CoreApp.Models.DataTransfer;

namespace CoreApp.DataService
{
    public class EmployeeService : BaseEntityService<Employee, DTO.Employee>, IEmployeeService
    {
        private readonly EmployeeDataProvider _dataProvider;
        private readonly IConfiguration _configuration;

        public EmployeeService(EmployeeDataProvider dataProvider,IConfiguration configuration) : base(dataProvider, configuration)
        {
            _dataProvider = dataProvider;
            _configuration = configuration;
        }
    }
}
