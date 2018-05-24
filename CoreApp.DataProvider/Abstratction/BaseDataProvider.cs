using AutoMapper.QueryableExtensions;
using CoreApp.DataProvider.DataContext;
using CoreApp.Models.DataTransfer;
using CoreApp.Models.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp.DataProvider.Abstratction
{
    public class EntityDataProviderBase<TEntity, TDto>
        where TEntity : BaseEntityModel
        where TDto : DtoBase
    {
        private DatabaseContext _context;

        protected DbSet<TEntity> Entities { get; set; }

        public DatabaseContext Context
        {
            get { return _context; }
            set
            {
                _context = value;
                Entities = _context.Set<TEntity>();
            }
        }

        public EntityDataProviderBase(DatabaseContext ctx)
        {
            Context = ctx;
        }

        public virtual async Task<IEnumerable<TDto>> ListOfEntitiesAsync() => await Entities.ProjectTo<TDto>().ToListAsync();
    }
}
