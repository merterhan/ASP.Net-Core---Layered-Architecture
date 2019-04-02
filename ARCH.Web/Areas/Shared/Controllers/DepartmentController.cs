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
using Microsoft.AspNetCore.Authorization;

namespace ARCH.Web.Areas.Shared.Controllers
{
    [Area("Shared")]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var departments = _departmentService.GetList();

            DepartmentListViewModel model = new DepartmentListViewModel
            {
                Department = departments
            };

            return View(model);
        }
    }
}
