using Service.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service.Controllers
{
    public class HomeController : Controller
    {
        private IUrlManager _urlManager;



        public HomeController(IUrlManager urlManager)
        {
            this._urlManager = urlManager;
        }
        [HttpGet]
        public JsonResult Index()
        {
            Random rnd = new Random();
            int extra = rnd.Next(1, 1000);
            var randomUrl = "www.google.com/randomLink" + extra;
            var result=_urlManager.ShortenUrl(randomUrl);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
