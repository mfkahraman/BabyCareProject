using BabyCareProject.Entity.Dtos.InstructorDtos;
using BabyCareProject.Entity.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IInstructorService
    {
        Task<List<ResultInstructorDto>> GetAllAsync();
        Task<ResultInstructorDto> GetByIdAsync(string id);
        Task CreateAsync(CreateInstructorDto dto);
        Task UpdateAsync(UpdateInstructorDto dto);
        Task DeleteAsync(string id);
    }
}
