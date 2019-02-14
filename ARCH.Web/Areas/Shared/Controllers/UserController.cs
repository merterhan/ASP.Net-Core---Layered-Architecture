using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARCH.DataAccess.Concrete.EntityFramework;
using ARCH.Entities.Concrete;
using ARCH.Business.Abstract;
using ARCH.Web.Areas.Shared.Models;

namespace ARCH.Web.Areas.Shared.Controllers
{
    [Area("Shared")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var users = _userService.GetAll();

            UserListViewModel model = new UserListViewModel
            {
                User = users
            };

            return View(model);
        }
    }
}
