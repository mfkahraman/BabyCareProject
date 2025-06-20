using BabyCareProject.Dtos.InstructorDtos;
using BabyCareProject.Services.InstructorServices;
using Booksaw.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService instructorService,
                                      IImageService imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await instructorService.GetAllInstroctarAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateInstructor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor(CreateInstructorDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "instructors");
                dto.ImageUrl = imagePath;
            }

            await instructorService.CreateInstructorAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInstructor(string id)
        {
            var value = await instructorService.GetInstructorByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "instructors");
                dto.ImageUrl = imagePath;
            }

            await instructorService.UpdateInstructorAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteInstructor(string id)
        {
            await instructorService.DeleteInstructorAsync(id);
            return RedirectToAction("Index");
        }




    }
}
