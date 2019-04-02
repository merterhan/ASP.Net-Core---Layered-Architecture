using ARCH.Business.Abstract;
using ARCH.Web.Entities;
using ARCH.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ARCH.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly IDepartmentService _departmentService;


        public HomeController(ISessionService sessionService, UserManager<CustomIdentityUser> userManager, IDepartmentService departmentService)
        {
            _sessionService = sessionService;
            _userManager = userManager;
            _departmentService = departmentService;
        }

        public ActionResult Index()
        {
            int pageSize = 2; //parametrik yap

            //Show username in session to view
            if (_sessionService.GetUser() == null)
                return RedirectToAction("Login", "Account");

            TempData.Add("user", _sessionService.GetUser());

            //var model = new UserListViewModel
            //{
            //    Users = _userManager.Users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync().Result.ToList(),
            //    PageCount = (int)Math.Ceiling(_userManager.Users.Count()/(double)pageSize),
            //    PageSize = pageSize,
            //    CurrentPage = page
            //};

            return View();
        }
    }
}