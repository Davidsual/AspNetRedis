using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavideTrotta.AspNet.Redis.Web.Models;
using DavideTrotta.AspNet.Redis.Web.Services;

namespace DavideTrotta.AspNet.Redis.Web.Controllers
{
    public class ResultController : Controller
    {
        private const string SessionName = "MyFistSessionVariableInRedis";
        private const string CacheName = "MyFirstCacheVariableInRedis";
        private readonly ICacheProvider _cacheProvider;
        public ResultController()
        {
            _cacheProvider = new CacheProvider();
        }
        // GET: Result
        public ActionResult Index()
        {
            //Retrieve Value from Session... after postback
            ResultViewModel vm = new ResultViewModel();

            vm.ValueStoredInRedis = Session[SessionName] as string;

            HomeViewModel vmHome = _cacheProvider.Get<HomeViewModel>(CacheName);

            TempData["IsCaching"] = (vmHome != null);

            return View(vm);
        }
    }
}