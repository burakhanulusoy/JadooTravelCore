using JadooTravelCore.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        private readonly ITesimonialService _tesimonialService;

        public _DefaultTestimonialComponentPartial(ITesimonialService tesimonialService)
        {
            _tesimonialService = tesimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _tesimonialService.GetAllTestimonialAsync();
            return View(values);
        }








    }
}
