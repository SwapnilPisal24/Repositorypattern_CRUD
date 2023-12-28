using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Entities;
using Repositorypattern.Repositories.Interfaces;
using Repositorypattern.UI.ViewComponents.UserInfoViewModels;

namespace Repositorypattern.UI.Controllers
{
    public class AuthController : Controller
    { 
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            var userinfo = await _userRepo.GetUserInfo(vm.Username, vm.Password);
            HttpContext.Session.SetInt32("UserId", userinfo.Id);
            HttpContext.Session.SetString("Username", userinfo.UserName);
            return RedirectToAction("Index", "Countries");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo
            {
                UserName = vm.Username,
                Password = vm.Password
            };
            await _userRepo.RegisterUser(model); 

            return RedirectToAction("Login");

        }
    }
}
