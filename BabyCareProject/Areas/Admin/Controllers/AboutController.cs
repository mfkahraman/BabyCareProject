using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Entity.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IAboutService aboutService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts = await aboutService.GetAllAsync();
            return View(abouts);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            if (ModelState.IsValid)
            {
                await aboutService.CreateAsync(createAboutDto);
                return RedirectToAction("Index");
            }

            return View(createAboutDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var about = await aboutService.GetByIdAsync(id);
            if (about == null)
                return NotFound();

            var dto = mapper.Map<UpdateAboutDto>(about);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            if (ModelState.IsValid)
            {
                await aboutService.UpdateAsync(updateAboutDto);
                return RedirectToAction("Index");
            }

            return View(updateAboutDto);
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            var about = await aboutService.GetByIdAsync(id);
            if (about == null)
                return NotFound();

            await aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
