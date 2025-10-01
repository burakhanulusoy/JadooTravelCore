using JadooTravelCore.Services.DestinationsServices;
using JadooTravelCore.Services.ReceiverMessageServices;
using JadooTravelCore.Services.ServiceServices;
using JadooTravelCore.Services.SupporterServices;
using JadooTravelCore.Services.TestimonialServices;
using JadooTravelCore.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JadooTravelCore.Dtos.DestinationDtos;

namespace JadooTravelCore.Controllers
{
    public class StaticksController : Controller
    {

        private readonly IDestinationService _destinationService;
        private readonly IReceiverMessageService _receiverMessageService;
        private readonly IServiceService _serviceService;
       private readonly ISupporterService _supporterService;
        private readonly ITesimonialService _Testimonialservices;
        private readonly IUserService _userService;

        public StaticksController(IDestinationService destinationService, IReceiverMessageService receiverMessageService, IServiceService serviceService, ISupporterService supporterService, ITesimonialService testimonialservices, IUserService userService)
        {
            _destinationService = destinationService;
            _receiverMessageService = receiverMessageService;
            _serviceService = serviceService;
            _supporterService = supporterService;
            _Testimonialservices = testimonialservices;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {


            var Destinationvalues =await _destinationService.GetAllDestinationAsync();
            var receiverMessage=await _receiverMessageService.GetAllReceiverMessageAsync();
            var serviceList=await _serviceService.GetAllServicesAsync();
            var suppoerterList = await _supporterService.GetAllSupporterAsync();
            var testimonialList=await _Testimonialservices.GetAllTestimonialAsync();
            var userList=await _userService.GetAllUserAsync();


            var chartData = new
            {
                names = Destinationvalues.Select(x => x.City).ToList(),
                prices = Destinationvalues.Select(x => x.Price).ToList(),
                capacities = Destinationvalues.Select(x => x.Capacity).ToList()
            };

            ViewBag.ChartData = Newtonsoft.Json.JsonConvert.SerializeObject(chartData);



           
            ViewBag.AvaragePrice=Destinationvalues.Average(x=>x.Price);

            decimal totalprice = 0;
            foreach(var item in Destinationvalues)
            {

                totalprice += (item.Capacity*item.Price);

            }
            ViewBag.TotalPrice = totalprice;


            ViewBag.CountReadMessage=receiverMessage.Where(x=>x.Status==true).Count();
            ViewBag.CountDontReadMessage = receiverMessage.Where(x => x.Status == false).Count();
            ViewBag.AdminCount = userList.Count();



            var MaxPriceTour=Destinationvalues.OrderByDescending(x=>x.Price).FirstOrDefault();
            var MinPriceTour=Destinationvalues.OrderBy(x=>x.Price).FirstOrDefault();

            ViewBag.maxPrice = MaxPriceTour.Price;
            ViewBag.maxCity=MaxPriceTour.City;
            ViewBag.maxCountry=MaxPriceTour.Country;


            ViewBag.minPrice = MinPriceTour.Price;
            ViewBag.minCity=MinPriceTour.City;
            ViewBag.mincountry=MinPriceTour.Country;

            ViewBag.testimonialCount=testimonialList.Count();





            var lastestDestination=Destinationvalues.OrderByDescending(x=>x.DestinationId).Take(4).ToList();

            ViewBag.lastestDestination=lastestDestination;



            var lastestAddUser=userList.OrderByDescending(x=>x.UserId).Take(4).ToList();

            ViewBag.lastAddUserList=lastestAddUser;








            return View(Destinationvalues);
        }
    }
}
