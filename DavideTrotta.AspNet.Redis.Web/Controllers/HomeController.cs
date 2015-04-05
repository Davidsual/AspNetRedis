using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavideTrotta.AspNet.Redis.Web.Models;
using DavideTrotta.AspNet.Redis.Web.Services;

namespace DavideTrotta.AspNet.Redis.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionName = "MyFistSessionVariableInRedis";
        private const string CacheName = "MyFirstCacheVariableInRedis";
        private readonly ICacheProvider _cacheProvider;
        public HomeController()
        {
            _cacheProvider = new CacheProvider();
        }
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

            vm.ValueStoredInRedis = string.Format("Store this value in session at: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt"));

            Session[SessionName] = vm.ValueStoredInRedis;
            //Cache view model
            _cacheProvider.Set(CacheName,vm);

            return View(vm);
        }

        public ActionResult RefreshMe()
        {
            //Retrieve Value from Session... after postback
            RefreshMeViewModel vm = new RefreshMeViewModel();

            vm.ValueStoredInRedis = Session[SessionName] as string;

            HomeViewModel vmHome = _cacheProvider.Get<HomeViewModel>(CacheName);

            TempData["IsCaching"] = (vmHome != null);

            return View(vm);
        }
    }
}