using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class GenericService<TEntity, TCreateDto, TUpdateDto, TResultDto> : IGenericService<TCreateDto, TUpdateDto, TResultDto, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TResultDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<TResultDto>>(entities);
        }

        public async Task<TResultDto> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TResultDto>(entity);
        }

        public async Task CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateAsync(entity);
        }

        public async Task UpdateAsync(TUpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<TResultDto>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await _repository.GetByFilterAsync(filter);
            return _mapper.Map<List<TResultDto>>(entities);
        }

        public async Task<TResultDto> GetSingleByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = (await _repository.GetByFilterAsync(filter)).FirstOrDefault();
            return _mapper.Map<TResultDto>(entity);
        }
    }
}
