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
            if(createBannerDto.ImageFile != null)
            {
                var imagePath = await imageService.SaveImageAsync(createBannerDto.ImageFile, "banners");
                createBannerDto.ImageUrl = imagePath;
            }

            if (ModelState.IsValid)
            {
                await bannerService.CreateAsync(createBannerDto);
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(createBannerDto.ImageUrl))
                await imageService.DeleteImageAsync(createBannerDto.ImageUrl);

            return View(createBannerDto);
        }
    }
}
