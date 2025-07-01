using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.TestimonialDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class TestimonialService : GenericService<Testimonial, CreateTestimonialDto, UpdateTestimonialDto, ResultTestimonialDto>, ITestimonialService
    {
        public TestimonialService(IGenericRepository<Testimonial> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
