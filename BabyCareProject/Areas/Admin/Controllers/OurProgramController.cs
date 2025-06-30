using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Business.Concrete;
using BabyCareProject.Entity.Dtos.OurProgramDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BabyCareProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurProgramController(IOurProgramService programService, 
                                    IInstructorService instructorService, 
                                    IMapper mapper,
                                    IImageService imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var programs = await programService.GetAllAsync();
            var instructors = await instructorService.GetAllAsync();

            var model = programs.Select(program =>
            {
                var instructor = instructors.FirstOrDefault(i => i.Id == program.InstructorId);
                return new OurProgramWithInstructorViewModel
                {
                    Program = program,
                    InstructorFullName = instructor != null ? $"{instructor.FirstName} {instructor.LastName}" : "Eğitmen bulunamadı",
                    InstructorTitle = instructor?.Title ?? "-"
                };
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOurProgram()
        {
            var instructors = await instructorService.GetAllAsync();
            ViewBag.Instructors = instructors;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOurProgram(CreateOurProgramDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "ourprograms");
                dto.ImageUrl = imagePath;
                ModelState.Remove(nameof(dto.ImageUrl)); // Validation conflict engellenir
            }

            if (ModelState.IsValid)
            {
                await programService.CreateAsync(dto);
                return RedirectToAction("Index");
            }

            var instructors = await instructorService.GetAllAsync();
            ViewBag.Instructors = instructors;
            return View(dto);
        }

        public async Task<IActionResult> UpdateOurProgram(string id)
        {
            var program = await programService.GetByIdAsync(id);
            if (program == null) return NotFound();

            var updateDto = mapper.Map<UpdateOurProgramDto>(program);

            var instructors = await instructorService.GetAllAsync();
            ViewBag.Instructors = instructors.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = $"{i.FirstName} {i.LastName} - {i.Title}"
            }).ToList();

            return View(updateDto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateOurProgram(UpdateOurProgramDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(dto.ImageFile, "ourprograms");
                dto.ImageUrl = imagePath;
                ModelState.Remove(nameof(dto.ImageUrl));
            }

            if (ModelState.IsValid)
            {
                await programService.UpdateAsync(dto);
                return RedirectToAction("Index");
            }

            var instructors = await instructorService.GetAllAsync();
            ViewBag.Instructors = instructors;
            return View(dto);
        }

        public async Task<IActionResult> DeleteOurProgram(string id)
        {
            await programService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ToggleStatus(string id)
        {
            var program = await programService.GetByIdAsync(id);
            if (program == null) return NotFound();

            program.IsActive = !program.IsActive;
            var dto = mapper.Map<UpdateOurProgramDto>(program);
            await programService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
