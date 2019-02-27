using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARCH.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISessionService _sessionService;

        public HomeController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public ActionResult Index()
        {
            //Show username in session to view
            return View();
        }
    }
}