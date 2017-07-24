using MusicJPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicJPlayer.Controllers
{
    public class HomeController : Controller
    {
        private MusicJPlayerContext db = new MusicJPlayerContext();

        public ActionResult Index()
        {
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

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Data()
        {
            var jsonData = (from m in db.MusicInfos.AsEnumerable()
                            join f in db.FileDetails.AsEnumerable()
                            on m.MusicInfoId equals f.MusicInfoId
                            select new
                            {
                                title = m.Title,
                                artist = m.Artist,
                                mp3 = new Uri(Request.Url, Url.Content("~/MusicFiles/" + f.FileName)),
                                //poster = new Uri(Request.Url, Url.Content("~/CoverArts/" + m.CoverArt ))
                            }).ToArray();

            return new JsonResult { Data = jsonData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult NoCssPlayer()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Player()
        {
            return PartialView("_Player");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}