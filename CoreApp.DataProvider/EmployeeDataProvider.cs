using CoreApp.DataProvider.Abstratction;
using CoreApp.DataProvider.DataContext;
using CoreApp.Models;
using DTO = CoreApp.Models.DataTransfer;
using Employee = CoreApp.Models.Models.Employee;

namespace CoreApp.DataProvider
{
    public class EmployeeDataProvider: EntityDataProviderBase<Employee, DTO.Employee>
    {
        public EmployeeDataProvider(DatabaseContext ctx) : base(ctx)
        {
        }
    }
}
