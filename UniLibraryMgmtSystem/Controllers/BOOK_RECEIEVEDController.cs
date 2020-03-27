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
    public class BOOK_RECEIEVEDController : Controller
    {
        private LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();

        // GET: BOOK_RECEIEVED
        public ActionResult Index()
        {
            var bOOK_RECEIEVED = db.BOOK_RECEIEVED.Include(b => b.BOOK).Include(b => b.MEMBER);
            return View(bOOK_RECEIEVED.ToList());
        }

        // GET: BOOK_RECEIEVED/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_RECEIEVED bOOK_RECEIEVED = db.BOOK_RECEIEVED.Find(id);
            if (bOOK_RECEIEVED == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_RECEIEVED);
        }

        // GET: BOOK_RECEIEVED/Create
        public ActionResult Create()
        {
            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME");
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID");
            return View();
        }

        // POST: BOOK_RECEIEVED/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DATE,BOOK_ID,MEMBER_ID,FINE,REMARKS")] BOOK_RECEIEVED bOOK_RECEIEVED)
        {
            if (ModelState.IsValid)
            {
                db.BOOK_RECEIEVED.Add(bOOK_RECEIEVED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME", bOOK_RECEIEVED.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID", bOOK_RECEIEVED.MEMBER_ID);
            return View(bOOK_RECEIEVED);
        }

        // GET: BOOK_RECEIEVED/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_RECEIEVED bOOK_RECEIEVED = db.BOOK_RECEIEVED.Find(id);
            if (bOOK_RECEIEVED == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME", bOOK_RECEIEVED.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID", bOOK_RECEIEVED.MEMBER_ID);
            return View(bOOK_RECEIEVED);
        }

        // POST: BOOK_RECEIEVED/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DATE,BOOK_ID,MEMBER_ID,FINE,REMARKS")] BOOK_RECEIEVED bOOK_RECEIEVED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK_RECEIEVED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME", bOOK_RECEIEVED.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID", bOOK_RECEIEVED.MEMBER_ID);
            return View(bOOK_RECEIEVED);
        }

        // GET: BOOK_RECEIEVED/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_RECEIEVED bOOK_RECEIEVED = db.BOOK_RECEIEVED.Find(id);
            if (bOOK_RECEIEVED == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_RECEIEVED);
        }

        // POST: BOOK_RECEIEVED/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK_RECEIEVED bOOK_RECEIEVED = db.BOOK_RECEIEVED.Find(id);
            db.BOOK_RECEIEVED.Remove(bOOK_RECEIEVED);
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
