using ARCH.Web.Entities;
using ARCH.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARCH.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private ISessionService _sessionService;
        private UserManager<CustomIdentityUser> _userManager;


        public HomeController(ISessionService sessionService, UserManager<CustomIdentityUser> userManager)
        {
            _sessionService = sessionService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //Show username in session to view
            if (_sessionService.GetUser() == null)
                return RedirectToAction("Login", "Account");

            TempData.Add("user", _sessionService.GetUser());

            var userList = _userManager.Users.AsNoTracking().ToListAsync().Result;

            return View(userList);
        }
    }
}