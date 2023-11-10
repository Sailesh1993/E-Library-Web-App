using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Common;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Shared;

namespace WebApi.Business.src.Implementations
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto> 
    {
        private readonly IBaseRepo<T> _baseRepo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> baseRepo, IMapper mapper)
        {
            _baseRepo = baseRepo;
            _mapper = mapper;
        }

        public virtual async Task<TReadDto> CreateOne(TCreateDto createDto)
        {
            try
            {
                var entity = await _baseRepo.CreateOne(_mapper.Map<T>(createDto));
                return _mapper.Map<TReadDto>(entity);
            }
            catch (Exception ex)
            {
                
                throw CustomErrorHandler.CreateEntityException();;
            }
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }

        public Task<TReadDto> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updated)
        {
            throw new NotImplementedException();
        }
    }
}