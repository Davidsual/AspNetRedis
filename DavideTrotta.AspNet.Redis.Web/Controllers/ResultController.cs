using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavideTrotta.AspNet.Redis.Web.Models;

namespace DavideTrotta.AspNet.Redis.Web.Controllers
{
    public class ResultController : Controller
    {
        private const string SessionName = "MyFistSessionVariableInRedis";
        // GET: Result
        public ActionResult Index()
        {
            //Retrieve Value from Session... after postback
            ResultViewModel vm = new ResultViewModel();

            vm.ValueStoredInRedis = Session[SessionName] as string;


            return View(vm);
        }
    }
}