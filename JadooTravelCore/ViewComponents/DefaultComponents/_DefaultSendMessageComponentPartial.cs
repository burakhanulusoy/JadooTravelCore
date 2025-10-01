using Microsoft.AspNetCore.Mvc;

namespace JadooTravelCore.ViewComponents.DefaultComponents
{
    public class _DefaultSendMessageComponentPartial:ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View();
        }



    }
}
