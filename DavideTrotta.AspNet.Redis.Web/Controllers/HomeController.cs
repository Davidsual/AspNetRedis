using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavideTrotta.AspNet.Redis.Web.Models;

namespace DavideTrotta.AspNet.Redis.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionName = "MyFistSessionVariableInRedis";
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            vm.ValueStoredInRedis = string.Format("Store this value in session at: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt"));

            Session[SessionName] = vm.ValueStoredInRedis;

            return View(vm);
        }

        public ActionResult RefreshMe()
        {
            //Retrieve Value from Session... after postback
            RefreshMeViewModel vm = new RefreshMeViewModel();

            vm.ValueStoredInRedis = Session[SessionName] as string;

            return View(vm);
        }
    }
}