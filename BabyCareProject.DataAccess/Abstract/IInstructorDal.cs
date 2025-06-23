using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.DataAccess.Abstract
{
    public interface IInstructorDal
    {
        Task<List<Instructor>> GetAllInstructorsAsync();
        Task<Instructor> GetInstructorByIdAsync(string id);
        Task CreateInstructorAsync(Instructor entity);
        Task UpdateInstructorAsync(Instructor entity);
        Task DeleteInstructorAsync(string id);
    }
}
