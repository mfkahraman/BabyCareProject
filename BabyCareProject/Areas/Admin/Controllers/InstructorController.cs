using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Entity.Dtos.InstructorDtos;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService instructorService,
                                      IImageService imageService,
                                      IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await instructorService.GetAllAsync();
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

            await instructorService.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInstructor(string id)
        {
            var value = await instructorService.GetByIdAsync(id);
            var dto = mapper.Map<UpdateInstructorDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "instructors");
                dto.ImageUrl = imagePath;
            }

            await instructorService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteInstructor(string id)
        {
            await instructorService.DeleteAsync(id);
            return RedirectToAction("Index");
        }




    }
}
