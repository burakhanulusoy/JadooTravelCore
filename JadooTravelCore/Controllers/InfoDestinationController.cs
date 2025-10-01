using JadooTravelCore.Services.DestinationsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    [AllowAnonymous]
    public class InfoDestinationController : Controller
    {
        IDestinationService _destinationService;

        public InfoDestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var values=await _destinationService.GetDestinationByIdAsync(id);
          
            return View(values);
        }







    }
}
