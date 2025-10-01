using JadooTravelCore.Dtos.ReceiverMessageDtos;
using JadooTravelCore.Models;
using JadooTravelCore.Services.ReceiverMessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IReceiverMessageService _receiverMessageService;

        public DefaultController(IReceiverMessageService receiverMessageService)
        {
            _receiverMessageService = receiverMessageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateReceiverMessageDto createReceiverMessageDto)
        {
            createReceiverMessageDto.Status=false;
            createReceiverMessageDto.ReceiverDate = DateTime.Now;
            await _receiverMessageService.CreateReceiverMessageAsync(createReceiverMessageDto);
            return RedirectToAction("Index");

        }








    }
}
