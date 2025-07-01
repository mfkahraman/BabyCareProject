using BabyCareProject.Entity.Dtos.TestimonialDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface ITestimonialService : IGenericService<CreateTestimonialDto,UpdateTestimonialDto,ResultTestimonialDto,Testimonial>
    {
    }
}
