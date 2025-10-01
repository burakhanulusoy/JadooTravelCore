using JadooTravelCore.Entities;
using JadooTravelCore.Models;
using JadooTravelCore.Services.UserServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewsModel loginViewsModel)
        {
           
            if(!ModelState.IsValid)//validasyon kotrolü
            {
                return View(loginViewsModel);
            }

            var value = await _userService.GetByUserName(loginViewsModel.UserName, loginViewsModel.UserPassword);//değeri ararttırma fast fail

            if(value is null)
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı.");
                return View(loginViewsModel);
            }

            var claims = new List<Claim>//sisteme giriş yapılınca biligileri turma
            {
                new Claim(ClaimTypes.Name,loginViewsModel.UserName),
            };
            var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);


            var authProporties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false
            };


           await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               authProporties);



            HttpContext.Session.SetString("UserName", loginViewsModel.UserName);


            return RedirectToAction("Index", "Staticks");

        }




        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserName");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");


        }














    }
}
