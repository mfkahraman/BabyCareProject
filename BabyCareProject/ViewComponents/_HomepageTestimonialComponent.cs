using BabyCareProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageTestimonialComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _HomepageTestimonialComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialService.GetAllAsync();

            return View(testimonials);
        }
    }
}
