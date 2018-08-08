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
            return Json("pass a url to /home/create in a post", JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Create(string url)
        {
            var result = _urlManager.ShortenUrl(url);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Expand(string abbreviation)
        {

            string url = this._urlManager.GetOriginalUrl(abbreviation);
            return this.RedirectPermanent(url);
        }

    }
}
