using BabyCareProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageTeamComponent(IInstructorService instructorService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allInstuctors = await instructorService.GetAllAsync();
            var lastThree = allInstuctors.OrderByDescending(x=> x.Id).Take(3).ToList();
            return View(lastThree);
        }
    }
}
