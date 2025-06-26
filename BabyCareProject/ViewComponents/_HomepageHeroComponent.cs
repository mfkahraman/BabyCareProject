using BabyCareProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageHeroComponent(IBannerService bannerService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banner = await bannerService.GetSingleByFilterAsync(x => x.IsActive);
            return View(banner);
        }
    }
}
