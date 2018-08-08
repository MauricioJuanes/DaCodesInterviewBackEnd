using Service.Business.Interfaces;
using Service.Data.Entities;
using Service.Models;
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
        public ActionResult Index()
        {
            return View(new Url());
        }
        public ActionResult Index(Url url)
        {
            if (ModelState.IsValid)
            {
                UrlInfo info = _urlManager.ShortenUrl(url.OriginalUrl);
                url.ShortUrl= string.Format("{0}://{1}{2}{3}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"), info.Abreviation);

            }
            return View(url);
        }
        public JsonResult Create(string url)
        {
            var result = _urlManager.ShortenUrl(url);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateMultiple(IEnumerable<string> urls)
        {
           
            var result =  urls.Select(url=> _urlManager.ShortenUrl(url));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Expand(string abbreviation)
        {

            string url = this._urlManager.GetOriginalUrl(abbreviation);
            return this.RedirectPermanent(url);
        }

    }
}
