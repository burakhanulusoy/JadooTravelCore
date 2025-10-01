using Microsoft.AspNetCore.Mvc;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultFooterComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
