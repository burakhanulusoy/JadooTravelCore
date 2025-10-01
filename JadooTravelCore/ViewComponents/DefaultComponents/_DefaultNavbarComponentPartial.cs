using Microsoft.AspNetCore.Mvc;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultNavbarComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
