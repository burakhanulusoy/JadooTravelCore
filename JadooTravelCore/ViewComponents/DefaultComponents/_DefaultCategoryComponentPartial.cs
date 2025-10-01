using JadooTravelCore.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultCategoryComponentPartial:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _DefaultCategoryComponentPartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _serviceService.GetAllServicesAsync();
            return View(values);
        }



    }
}
