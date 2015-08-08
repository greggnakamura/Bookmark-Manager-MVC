using Bookmark_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmark_Manager.Controllers
{
    public class HomeController : Controller
    {
        private BookmarkManagerDB db = new BookmarkManagerDB();

        public ActionResult Index()
        {
            var query = (from r in db.Bookmarks
                        orderby r.DateCreated descending
                        select r).Take(5);

            return View(query);
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
    }
}