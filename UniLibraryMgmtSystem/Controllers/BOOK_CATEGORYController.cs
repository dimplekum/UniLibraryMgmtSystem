using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniLibraryMgmtSystem.Models;

namespace UniLibraryMgmtSystem.Controllers
{
    public class BOOK_CATEGORYController : Controller
    {
        private LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();

        // GET: BOOK_CATEGORY
        public ActionResult Index()
        {
            return View(db.BOOK_CATEGORY.ToList());
        }

        // GET: BOOK_CATEGORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_CATEGORY bOOK_CATEGORY = db.BOOK_CATEGORY.Find(id);
            if (bOOK_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_CATEGORY);
        }

        // GET: BOOK_CATEGORY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOOK_CATEGORY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME")] BOOK_CATEGORY bOOK_CATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.BOOK_CATEGORY.Add(bOOK_CATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOOK_CATEGORY);
        }

        // GET: BOOK_CATEGORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_CATEGORY bOOK_CATEGORY = db.BOOK_CATEGORY.Find(id);
            if (bOOK_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_CATEGORY);
        }

        // POST: BOOK_CATEGORY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME")] BOOK_CATEGORY bOOK_CATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK_CATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOK_CATEGORY);
        }

        // GET: BOOK_CATEGORY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_CATEGORY bOOK_CATEGORY = db.BOOK_CATEGORY.Find(id);
            if (bOOK_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_CATEGORY);
        }

        // POST: BOOK_CATEGORY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK_CATEGORY bOOK_CATEGORY = db.BOOK_CATEGORY.Find(id);
            db.BOOK_CATEGORY.Remove(bOOK_CATEGORY);
            db.SaveChanges();
            return RedirectToAction("Index");
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
