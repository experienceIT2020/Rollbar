using Rollbar;
using Rollbar.Net.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RBFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                int value = 1 / int.Parse("0");
            }
            catch (System.Exception ex)
            {
                RollbarLocator.RollbarInstance.AsBlockingLogger(TimeSpan.FromSeconds(1)).Error(ex);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            IRollbarPackage packagingStrategy = new ExceptionContextPackage(filterContext, "EXCEPTION intercepted by Controller.OnException(...)");
            RollbarLocator.RollbarInstance.Critical(packagingStrategy);
        }
    }
}
