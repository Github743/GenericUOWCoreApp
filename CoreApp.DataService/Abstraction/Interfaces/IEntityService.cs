using CoreApp.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp.DataService.Abstraction.Interfaces
{
    public interface IEntityService<TDto> : IDisposable
        where TDto : DtoBase
    {
        int CurrentUserId { get; set; }
        int CurrentEmployeeId { get; set; }

        Task<IEnumerable<TDto>> ListOfDtoAsync();
    }
}
