using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IGenericService<TCreateDto, TUpdateDto, TResultDto>
    {
        Task<List<TResultDto>> GetAllAsync();
        Task<TResultDto> GetByIdAsync(string id);
        Task CreateAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDto dto);
        Task DeleteAsync(string id);
    }
}
