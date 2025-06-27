using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Entity.Dtos.OurServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurServiceController(IOurServiceService ourServiceService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var services = await ourServiceService.GetAllAsync();
            return View(services);
        }

        public IActionResult CreateOurService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOurService(CreateOurServiceDto createDto)
        {
            if (ModelState.IsValid)
            {
                await ourServiceService.CreateAsync(createDto);
                return RedirectToAction("Index");
            }

            return View(createDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOurService(string id)
        {
            var service = await ourServiceService.GetByIdAsync(id);
            if (service == null) return NotFound();

            var updateDto = mapper.Map<UpdateOurServiceDto>(service);
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOurService(UpdateOurServiceDto updateDto)
        {
            if (ModelState.IsValid)
            {
                await ourServiceService.UpdateAsync(updateDto);
                return RedirectToAction("Index");
            }

            return View(updateDto);
        }

        public async Task<IActionResult> DeleteOurService(string id)
        {
            var service = await ourServiceService.GetByIdAsync(id);
            if (service == null) return NotFound();

            await ourServiceService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
