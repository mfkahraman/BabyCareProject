using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IGenericService<TCreateDto, TUpdateDto, TResultDto,TEntity>
    {
        Task<List<TResultDto>> GetAllAsync();
        Task<TResultDto> GetByIdAsync(string id);
        Task<List<TResultDto>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<TResultDto> GetSingleByFilterAsync(Expression<Func<TEntity, bool>> filter); // optional

        Task CreateAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDto dto);
        Task DeleteAsync(string id);
    }
}
