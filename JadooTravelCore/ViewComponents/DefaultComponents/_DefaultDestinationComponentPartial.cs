using JadooTravelCore.Services.DestinationsServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultDestinationComponentPartial:ViewComponent
    {

        private readonly IDestinationService _destinationService;

        public _DefaultDestinationComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _destinationService.GetAllDestinationAsync();
            return View(values);
        }



    }
}
