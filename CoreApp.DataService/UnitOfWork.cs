using CoreApp.DataProvider.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CoreApp.DataService
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlite(configuration["ConnectionStrings:dbConnection"]);
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        public DatabaseContext GetContext() => _context;

        #region IDisposable
        public void Dispose()
        {
            _context?.Dispose();
        }
        #endregion
    }
}
