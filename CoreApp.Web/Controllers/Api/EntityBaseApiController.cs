using AutoMapper;
using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Models.DataTransfer;
using CoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp.Web.Controllers.Api
{
    public class EntityBaseApiController<TViewModel, TDto> : ImsBaseApiController
        where TDto : DtoBase
        where TViewModel : BaseViewModel
    {
        private readonly IEntityService<TDto> _service;
        private readonly IConfiguration _configuration;
        public IEntityService<TDto> EntityService => _service;

        public EntityBaseApiController(IEntityService<TDto> entityService,IConfiguration configuration)
        {
            _service = entityService;
            _configuration = configuration;
        }

        protected async Task<IActionResult> GetAll(Func<IEntityService<TDto>, Task<IEnumerable<DtoBase>>> func)
        {
            return await ServiceCall(async entityService => {
                var dtos = await func(entityService);
                var viewModels = Mapper.Map<IEnumerable<TViewModel>>(dtos);
                if (viewModels != null)
                {
                    return new ObjectResult(viewModels);
                }
                return NotFound();
            });
        }

        protected async Task<IActionResult> GetAll()
        {

            return await ServiceCall(async entityService => {
                var dtos = await entityService.ListOfDtoAsync();
                var viewModels = Mapper.Map<IEnumerable<TViewModel>>(dtos);
                if (viewModels != null)
                {
                    return new ObjectResult(viewModels);
                }
                return NotFound();
            });

        }

        protected async Task<IActionResult> ServiceCall(Func<IEntityService<TDto>, Task<IActionResult>> action)
        {
            try
            {
                if (CurrentUserId != null) _service.CurrentUserId = CurrentUserId.Value;
                if (CurrentEmployeeId != null) _service.CurrentEmployeeId = CurrentEmployeeId.Value;
                return await action(_service);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ValidationError", ex.Message);
                return BadRequest(ModelState);
            }

        }

        //protected async Task<IActionResult> Add(BaseViewModel viewModel)
        //    => await ServiceCall(async entitySerivce => await entitySerivce.AddAsync(Mapper.Map<TDto>(viewModel)));

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return await GetAll();
        }

        // POST api/values
        //[HttpPost]
        //public virtual async Task<IActionResult> Post([FromBody]TViewModel dataObject)
        //{
        //    return await Add(dataObject);
        //}
    }
}
