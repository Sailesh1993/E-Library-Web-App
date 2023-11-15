using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Domain.src.Shared;

namespace WebApi.Controller.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudController <T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService <T, TReadDto, TCreateDto, TUpdateDto> _baseService;

        public CrudController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }  

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            var list = (await _baseService.GetAll(queryOptions)).ToArray();
            return Ok(list);
        }
    }
}