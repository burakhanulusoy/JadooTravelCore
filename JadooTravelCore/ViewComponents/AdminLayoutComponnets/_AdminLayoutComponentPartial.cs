using Microsoft.AspNetCore.Mvc;

namespace JadooTravelCore.ViewComponents.AdminLayoutComponnets
{
    public class _AdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
