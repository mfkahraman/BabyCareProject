using AutoMapper;
using BabyCareProject.Entity.Dtos.TestimonialDtos;
using BabyCareProject.Entity.Entities;

namespace BabyCareProject.Business.Mappings
{
    public class TestimonialMappings : Profile
    {
        public TestimonialMappings()
        {
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial,ResultTestimonialDto>().ReverseMap();
            CreateMap<UpdateTestimonialDto, ResultTestimonialDto>().ReverseMap();
        }
    }
}
