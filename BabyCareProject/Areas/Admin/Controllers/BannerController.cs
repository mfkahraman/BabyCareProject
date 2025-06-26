using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Entity.Dtos.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController(IBannerService bannerService,
                                    IImageService imageService,
                                   IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var banners = await bannerService.GetAllAsync();
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            if (createBannerDto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(createBannerDto.ImageFile, "banners");
                createBannerDto.ImageUrl = imagePath;

                // 💡 Bu satır kritik: imageurl için gereksiz validasyon engellenmiş olur
                ModelState.Remove(nameof(createBannerDto.ImageUrl));
            }

            if (ModelState.IsValid)
            {
                await bannerService.CreateAsync(createBannerDto);
                return RedirectToAction("Index");
            }

            return View(createBannerDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(string id)
        {
            var banner = await bannerService.GetByIdAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            var updateBannerDto = mapper.Map<UpdateBannerDto>(banner);
            return View(updateBannerDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            if (updateBannerDto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(updateBannerDto.ImageFile, "banners");
                updateBannerDto.ImageUrl = imagePath;
                ModelState.Remove(nameof(updateBannerDto.ImageUrl));
            }
            if (ModelState.IsValid)
            {
                await bannerService.UpdateAsync(updateBannerDto);
                return RedirectToAction("Index");
            }
            return View(updateBannerDto);
        }

        public async Task<IActionResult> DeleteBanner(string id)
        {
            var banner = await bannerService.GetByIdAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            // Delete the image file from the server
            if (!string.IsNullOrEmpty(banner.ImageUrl))
            {
                await imageService.DeleteImageAsync(banner.ImageUrl);
            }
            await bannerService.DeleteAsync(id);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> ToggleStatus(string id)
        {
            var banner = await bannerService.GetByIdAsync(id);
            if (banner == null) return NotFound();

            banner.IsActive = !banner.IsActive;
            var dto = mapper.Map<UpdateBannerDto>(banner);
            await bannerService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

    }
}
