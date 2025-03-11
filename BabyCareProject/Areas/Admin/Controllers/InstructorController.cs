using BabyCareProject.Dtos.InstructorDtos;
using BabyCareProject.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService instructorService) : Controller
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
