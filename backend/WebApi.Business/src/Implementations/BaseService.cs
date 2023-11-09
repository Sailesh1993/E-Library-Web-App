using WebApi.Business.src.Abstractions;
using WebApi.Domain.src.Abstractions;

namespace WebApi.Business.src.Implementations
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto> 
    {
        private readonly IBaseRepo<T> _baseRepo;
    }
}