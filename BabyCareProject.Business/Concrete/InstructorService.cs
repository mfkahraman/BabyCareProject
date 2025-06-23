using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.InstructorDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class InstructorService(IInstructorDal instructorDal,
                                   IMapper mapper) : IInstructorService
    {
        public async Task CreateAsync(CreateInstructorDto dto)
        {
            var entity = mapper.Map<Instructor>(dto);
            await instructorDal.CreateInstructorAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await instructorDal.DeleteInstructorAsync(id);
        }

        public async Task<List<ResultInstructorDto>> GetAllAsync()
        {
            var entities = await instructorDal.GetAllInstructorsAsync();
            return mapper.Map<List<ResultInstructorDto>>(entities);
        }

        public async Task<ResultInstructorDto> GetByIdAsync(string id)
        {
            var entity = await instructorDal.GetInstructorByIdAsync(id);
            return mapper.Map<ResultInstructorDto>(entity);
        }

        public async Task UpdateAsync(UpdateInstructorDto dto)
        {
            var entity = mapper.Map<Instructor>(dto);
            await instructorDal.UpdateInstructorAsync(entity);
        }

    }
}
