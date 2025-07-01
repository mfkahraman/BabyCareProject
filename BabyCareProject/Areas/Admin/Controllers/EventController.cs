using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Business.Concrete;
using BabyCareProject.Entity.Dtos.EventDtos;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IImageService imageService, IMapper mapper)
        {
            _eventService = eventService;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllAsync();
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await _imageService.SaveImageAsync(dto.ImageFile, "events");
                dto.ImageUrl = imagePath;
                ModelState.Remove(nameof(dto.ImageUrl)); // Validation conflict engellenir
            }

            if (ModelState.IsValid)
            {
                await _eventService.CreateAsync(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var entity = await _eventService.GetByIdAsync(id);
            var dto = _mapper.Map<UpdateEventDto>(entity);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEventDto dto)
        {
            if (dto.ImageFile != null)
            {
                var imagePath = await _imageService.SaveImageAsync(dto.ImageFile, "ourprograms");
                dto.ImageUrl = imagePath;
                ModelState.Remove(nameof(dto.ImageUrl));
            }

            if (ModelState.IsValid)
            {
                await _eventService.UpdateAsync(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _eventService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
