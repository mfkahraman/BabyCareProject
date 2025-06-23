using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.DataAccess.Concrete
{
    public class InstructorDal(IMongoCollection<Instructor> instructorCollection) : IInstructorDal
    {
        public async Task CreateInstructorAsync(Instructor entity)
        {
            await instructorCollection.InsertOneAsync(entity);
        }

        public async Task DeleteInstructorAsync(string id)
        {
            await instructorCollection.DeleteOneAsync(x => x.InstructorId == id);
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await instructorCollection.AsQueryable().ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(string id)
        {
            return await instructorCollection.Find(x => x.InstructorId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateInstructorAsync(Instructor entity)
        {
           await instructorCollection.FindOneAndReplaceAsync(x => x.InstructorId == entity.InstructorId, entity);
        }
    }
}
