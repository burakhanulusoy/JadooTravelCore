using JadooTravelCore.Services.SupporterServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultSupporterComponentPartial:ViewComponent
    {

        private readonly ISupporterService _supporterService;

        public _DefaultSupporterComponentPartial(ISupporterService supporterService)
        {
            _supporterService = supporterService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _supporterService.GetAllSupporterAsync();
            return View(values);
        }







    }
}
