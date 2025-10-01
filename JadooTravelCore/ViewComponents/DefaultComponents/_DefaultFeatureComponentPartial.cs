using JadooTravelCore.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeatureComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _featureService.GetAllFeatureAsync();
            return View(value);
        }



    }
}
