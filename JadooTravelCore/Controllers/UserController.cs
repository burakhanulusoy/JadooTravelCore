using JadooTravelCore.Dtos.UserDto;
using JadooTravelCore.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravelCore.Controllers
{
    public class UserController : Controller
    {

        private  readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> UserList()
        {
            var value= await _userService.GetAllUserAsync();
            return View(value);
        }


        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {

            await _userService.CreateUserAsync(createUserDto);
            return RedirectToAction("UserList");

        }


        public async Task<IActionResult> DeleteUser(string id)
        {

            await _userService.DeleteUserAsync(id);
            return RedirectToAction("UserList");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var value=await _userService.GetByIdUserAsync(id);
            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            await _userService.UpdateUserAsync(updateUserDto);
            return RedirectToAction("UserList");

        }
















    }
}
