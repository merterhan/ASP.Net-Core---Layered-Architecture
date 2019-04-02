using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Web.Entities;
using ARCH.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace ARCH.Web.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        private readonly UserManager<CustomIdentityUser> _userManager;

        public UserListViewComponent(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        public ViewViewComponentResult Invoke(int page = 1)
        {
            int pageSize = 2;

            var model = new UserListViewModel
            {
                Users = _userManager.Users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync().Result.ToList(),
                PageCount = (int)Math.Ceiling(_userManager.Users.Count() / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View(model);
        }
    }
}
