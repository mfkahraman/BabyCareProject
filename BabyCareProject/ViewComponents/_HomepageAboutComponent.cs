using BabyCareProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageAboutComponent(IAboutService aboutService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await aboutService.GetSingleByFilterAsync(x => x.Title != null);
            return View(about);
        }
    }
}
