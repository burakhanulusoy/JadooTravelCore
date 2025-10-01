using Microsoft.AspNetCore.Mvc;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultHeadComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
