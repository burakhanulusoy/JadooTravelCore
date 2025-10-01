using JadooTravelCore.Dtos.SupporterDtos;
using JadooTravelCore.Services.SupporterServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    public class SupporterController : Controller
    {
        private readonly ISupporterService _supporterService;

        public SupporterController(ISupporterService supporterService)
        {
            _supporterService = supporterService;
        }

        public async Task<IActionResult> SupporterList()
        {
            var values=await _supporterService.GetAllSupporterAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSupporter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSupporter(CreateSupporterDto createSupporterDto)
        {
              await _supporterService.CreateSuppoerterAsync(createSupporterDto);
            return RedirectToAction("SupporterList");
        }

        public async Task<IActionResult> DeleteSupporter(string id)
        {
            await _supporterService.DeleteSuppoerterAsync(id);
            return RedirectToAction("SupporterList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSupporter(string id)
        {
            var value=await _supporterService.GetByIdSupporterAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSupporter(UpdateSupporterDto updateSupporterDto)
        {
            await _supporterService.UpdateSuppoerterAsync(updateSupporterDto);
            return RedirectToAction("SupporterList");
        }

































    }
}
