using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Business.Concrete;
using BabyCareProject.Business.ValidationRules.TestimonialValidators;
using BabyCareProject.Entity.Dtos.TestimonialDtos;
using BabyCareProject.Entity.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper, IImageService imageService)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialService.GetAllAsync();
            var mapped = _mapper.Map<List<ResultTestimonialDto>>(testimonials);
            return View(mapped);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await _imageService.SaveImageAsync(dto.ImageFile, "testimonials");
                dto.ImageUrl = imagePath;
                ModelState.Remove(nameof(dto.ImageUrl)); // Validation conflict engellenir
            }

            if (ModelState.IsValid)
            {
                await _testimonialService.CreateAsync(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var entity = await _testimonialService.GetByIdAsync(id);
            var dto = _mapper.Map<UpdateTestimonialDto>(entity);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await _imageService.SaveImageAsync(dto.ImageFile, "testimonials");
                dto.ImageUrl = imagePath;
                ModelState.Remove(nameof(dto.ImageUrl));
            }

            if (ModelState.IsValid)
            {
                await _testimonialService.UpdateAsync(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _testimonialService.GetByIdAsync(id);
            if (entity != null)
            {
                await _imageService.DeleteImageAsync(entity.ImageUrl);
                await _testimonialService.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }
    }
}
