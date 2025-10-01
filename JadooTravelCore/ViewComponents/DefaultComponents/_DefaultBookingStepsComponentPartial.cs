using Microsoft.AspNetCore.Mvc;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultBookingStepsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
