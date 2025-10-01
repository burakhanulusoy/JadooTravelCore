using JadooTravelCore.Dtos.TestimonialDtos;
using JadooTravelCore.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITesimonialService _tesimonialService;

        public TestimonialController(ITesimonialService tesimonialService)
        {
            _tesimonialService = tesimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var user=await _tesimonialService.GetAllTestimonialAsync();
            return View(user);
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _tesimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _tesimonialService.GetByIdTestimonialAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _tesimonialService.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");

        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTetimonialDto createTetimonialDto)
        {
            await _tesimonialService.CreateTestimonialAsync(createTetimonialDto);
            return RedirectToAction("TestimonialList");

        }












    }
}
