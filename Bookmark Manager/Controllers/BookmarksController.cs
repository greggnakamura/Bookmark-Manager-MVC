using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bookmark_Manager.Models;

namespace Bookmark_Manager.Controllers
{
    public class BookmarksController : Controller
    {
        private BookmarkManagerDB db = new BookmarkManagerDB();

        // GET: Bookmarks
        public ActionResult Index()
        {
            return View(db.Bookmarks.ToList());
        }

        // GET: Bookmarks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Create
        public ActionResult Create(Tag tag)
        {
            var tags = db.Tags.Select(r => new {
                tagName = r.Tags
            }).ToList();

            ViewBag.Tags = new MultiSelectList(tags, "tagName", "tagName");

            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateCreated,Title,Url,Description,Tags")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                bookmark.DateCreated = DateTime.Now;
                db.Bookmarks.Add(bookmark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateModified,Title,Url,Description,Tags")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                bookmark.DateModified = DateTime.Now;
                db.Entry(bookmark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = db.Bookmarks.Find(id);
            db.Bookmarks.Remove(bookmark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CssTags()
        {
            var query = from r in db.Bookmarks
                        where(r.Tags.Contains("css"))
                        orderby r.Tags ascending
                        select r;

            return PartialView("_CssTags", query);
        }

        public ActionResult JavascriptTags()
        {
            var query = from r in db.Bookmarks
                        where (r.Tags.Contains("javascript"))
                        orderby r.Tags ascending
                        select r;

            return PartialView("_JavascriptTags", query);
        }

        public ActionResult SeoTags()
        {
            var query = from r in db.Bookmarks
                        where (r.Tags.Contains("seo"))
                        orderby r.Tags ascending
                        select r;

            return PartialView("_SeoTags", query);
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
