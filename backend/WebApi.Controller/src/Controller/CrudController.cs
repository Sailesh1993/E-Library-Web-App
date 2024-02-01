using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Domain.src.Shared;

namespace WebApi.Controller.src.Controller
{
    [ApiController]
    [Route("api/v1/[controller]s")]
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

        [HttpGet("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> GetOneById([FromRoute] Guid id)
        {
            var foundItem = await _baseService.GetOneById(id);
            if(foundItem == null)
            {
                return NotFound();
            }
            return Ok(foundItem);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TReadDto>> CreateOne( [FromBody] TCreateDto createDto)
        {
            var createdObject = await _baseService.CreateOne(createDto);
            return CreatedAtAction(nameof(CreateOne), createdObject);
        }

        [HttpPatch("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] TUpdateDto updateDto)
        {
            return await _baseService.UpdateOneById(id, updateDto);
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            return StatusCode(204, await _baseService.DeleteOneById(id));
        }
    }
}