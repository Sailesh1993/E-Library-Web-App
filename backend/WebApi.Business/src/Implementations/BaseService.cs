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
            catch (Exception)
            {
                
                throw CustomErrorHandler.CreateEntityException();
            }
        }

        public async Task<bool> DeleteOneById(Guid id)
        {
            Console.WriteLine("Hello");
            var foundItem = await _baseRepo.GetOneById(id);
            if(foundItem is not null)
            {
                _baseRepo.DeleteOneById(foundItem);
                return true;
            }
            else
            {
                throw CustomErrorHandler.NotFoundException();
            }
        }

        public async Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions)
        {
            try
            {
                var allLists = await _baseRepo.GetAll(queryOptions);
                var dtoAllLists = _mapper.Map<IEnumerable<TReadDto>>(allLists);
                if(dtoAllLists.Any())
                {
                    return dtoAllLists;
                }
                else
                {
                    throw CustomErrorHandler.NotFoundException("There is no item in the Repo");
                }
            }
            catch (Exception)
            {
                
                throw CustomErrorHandler.NotFoundException();
            }
        }

        public async Task<TReadDto> GetOneById(Guid id)
        {
            try
            {
                var entity = _mapper.Map<TReadDto>(await _baseRepo.GetOneById(id));
                if(entity is not null)
                {
                    return entity;
                }
                else
                {
                    throw new Exception($"item with {id} id is not found");
                }
            }
            catch (Exception)
            {
                
                throw CustomErrorHandler.NotFoundException();
            }
        }

        public async Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updated)
        {
            try
            {
                var foundItem = await _baseRepo.GetOneById(id);
                if(foundItem == null)
                {
                    throw new Exception($"Item with {id} not found");
                }
                else
                {
                    _mapper.Map(updated, foundItem);
                    await _baseRepo.UpdateOneById(foundItem);
                    return _mapper.Map<TReadDto>(foundItem);
                }
            }
            catch (Exception)
            {
                
                throw CustomErrorHandler.NotFoundException();
            }
        }
    }
}