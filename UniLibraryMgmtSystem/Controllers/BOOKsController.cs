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
    public class BOOKsController : Controller
    {
        private LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();

        // GET: BOOKs
        public ActionResult Index()
        {
            var bOOKs = db.BOOKs.Include(b => b.BOOK_CATEGORY);
            return View(bOOKs.ToList());
        }

        // GET: BOOKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.BOOK_CATEGORY_ID = new SelectList(db.BOOK_CATEGORY, "ID", "NAME");
            ViewBag.PUBLISHER_ID = new SelectList(db.PUBLISHERs, "ID", "NAME");

            return View();
        }

        // POST: BOOKs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BOOK_CATEGORY_ID,PUBLISHER_ID,BOOK_NAME,BOOK_SUBJECT,BOOK_DESCRIPTION")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOKs.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BOOK_CATEGORY_ID = new SelectList(db.BOOK_CATEGORY, "ID", "NAME", bOOK.BOOK_CATEGORY_ID);
            return View(bOOK);
        }

        // GET: BOOKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOOK_CATEGORY_ID = new SelectList(db.BOOK_CATEGORY, "ID", "NAME", bOOK.BOOK_CATEGORY_ID);
            ViewBag.PUBLISHER_ID = new SelectList(db.PUBLISHERs, "ID", "NAME");

            return View(bOOK);
        }

        // POST: BOOKs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BOOK_CATEGORY_ID,PUBLISHER_ID,BOOK_NAME,BOOK_SUBJECT,BOOK_DESCRIPTION")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BOOK_CATEGORY_ID = new SelectList(db.BOOK_CATEGORY, "ID", "NAME", bOOK.BOOK_CATEGORY_ID);
            return View(bOOK);
        }

        // GET: BOOKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            db.BOOKs.Remove(bOOK);
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
