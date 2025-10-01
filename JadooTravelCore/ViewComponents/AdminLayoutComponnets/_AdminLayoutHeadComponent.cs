using JadooTravelCore.Services.ReceiverMessageServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.ViewComponents.AdminLayoutComponnets
{
    public class _AdminLayoutHeadComponent:ViewComponent
    {
        private readonly IReceiverMessageService receiverMessageService;

        public _AdminLayoutHeadComponent(IReceiverMessageService receiverMessageService)
        {
            this.receiverMessageService = receiverMessageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await receiverMessageService.GetAllReceiverMessageAsync();
            return View(values);
        }



    }
}
