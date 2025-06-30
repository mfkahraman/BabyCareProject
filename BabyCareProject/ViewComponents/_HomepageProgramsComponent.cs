using BabyCareProject.Business.Abstract;
using BabyCareProject.Entity.Dtos.OurProgramDtos;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageProgramsComponent(IOurProgramService programService, IInstructorService instructorService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var programs = await programService.GetByFilterAsync(x => x.IsActive);
            var instructors = await instructorService.GetAllAsync();

            var result = programs.Select(p =>
            {
                var instructor = instructors.FirstOrDefault(i => i.Id == p.InstructorId);
                return new OurProgramWithInstructorViewModel
                {
                    Program = p,
                    InstructorFullName = $"{instructor?.FirstName} {instructor?.LastName}",
                    InstructorTitle = instructor?.Title,
                    InstructorImageUrl = instructor?.ImageUrl
                };
            }).Take(3).ToList();

            return View(result);
        }
    }
}
