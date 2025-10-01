using AutoMapper;
using JadooTravelCore.Dtos.ReceiverMessageDtos;
using JadooTravelCore.Services.ReceiverMessageServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    public class ReceiverMessageController : Controller
    {
        private readonly IReceiverMessageService _receiverMessageService;
        private readonly IMapper _mapper;

        public ReceiverMessageController(IReceiverMessageService receiverMessageService, IMapper mapper)
        {
            _receiverMessageService = receiverMessageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MessageList()
        {
            var values=await _receiverMessageService.GetAllReceiverMessageAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _receiverMessageService.DeleteReceiverMessageAsync(id);
            return RedirectToAction("MessageList");
        }


        public async Task<IActionResult> DeatilMessage(string id)
        {

            var value = await _receiverMessageService.GetByIdReceiverMessageAsync(id);
            return View(value);
        }
        
        public async Task<IActionResult> ReadMessage(string id)
        {

            var value = await _receiverMessageService.GetByIdReceiverMessageAsync(id);
            value.Status = true;
            var newValue=_mapper.Map<UpdateReceiverMessageDto>(value);  
            await _receiverMessageService.UpdateReceiverMessageAsync(newValue);
            return RedirectToAction("MessageList");


        }






    }
}
