using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.Entity.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService productService,
                                   IInstructorService instructorService,
                                   IMapper mapper) : Controller
    {
        public async Task <IActionResult> Index()
        {
            var values = await productService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var insturctors = await instructorService.GetAllAsync();
            ViewBag.Instructors = (from x in insturctors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await productService.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var insturctors = await instructorService.GetAllAsync();
            ViewBag.Instructors = (from x in insturctors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();

            var value = await productService.GetByIdAsync(id);
            var dto = mapper.Map<UpdateProductDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await productService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
