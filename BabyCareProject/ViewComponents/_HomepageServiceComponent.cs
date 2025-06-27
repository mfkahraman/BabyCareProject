using BabyCareProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageServiceComponent(IOurServiceService service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await service.GetByFilterAsync(
                x => x.IsActive == true);
            var fourServices = services.Take(4).ToList();
            return View(fourServices);
        }
    }
}
