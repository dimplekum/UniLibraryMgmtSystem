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
    public class BOOK_ISSUEController : Controller
    {
        private LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();

        // GET: BOOK_ISSUE
        public ActionResult Index()
        {
            var bOOK_ISSUE = db.BOOK_ISSUE.Include(b => b.BOOK).Include(b => b.MEMBER);
            return View(bOOK_ISSUE.ToList());
        }

        // GET: BOOK_ISSUE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_ISSUE bOOK_ISSUE = db.BOOK_ISSUE.Find(id);
            if (bOOK_ISSUE == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_ISSUE);
        }

        // GET: BOOK_ISSUE/Create
        public ActionResult Create()
        {
            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME");
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID");
            return View();
        }

        // POST: BOOK_ISSUE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ISSUE_DATE,BOOK_ID,MEMBER_ID,NO_OF_DAYS,FINE,REMARKS")] BOOK_ISSUE bOOK_ISSUE)
        {
            if (ModelState.IsValid)
            {
                db.BOOK_ISSUE.Add(bOOK_ISSUE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME", bOOK_ISSUE.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID", bOOK_ISSUE.MEMBER_ID);
            return View(bOOK_ISSUE);
        }

        // GET: BOOK_ISSUE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_ISSUE bOOK_ISSUE = db.BOOK_ISSUE.Find(id);
            if (bOOK_ISSUE == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME", bOOK_ISSUE.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID", bOOK_ISSUE.MEMBER_ID);
            return View(bOOK_ISSUE);
        }

        // POST: BOOK_ISSUE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ISSUE_DATE,BOOK_ID,MEMBER_ID,NO_OF_DAYS,FINE,REMARKS")] BOOK_ISSUE bOOK_ISSUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK_ISSUE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BOOK_ID = new SelectList(db.BOOKs, "ID", "BOOK_NAME", bOOK_ISSUE.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERs, "ID", "MEMBERSHIP_ID", bOOK_ISSUE.MEMBER_ID);
            return View(bOOK_ISSUE);
        }

        // GET: BOOK_ISSUE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_ISSUE bOOK_ISSUE = db.BOOK_ISSUE.Find(id);
            if (bOOK_ISSUE == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_ISSUE);
        }

        // POST: BOOK_ISSUE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK_ISSUE bOOK_ISSUE = db.BOOK_ISSUE.Find(id);
            db.BOOK_ISSUE.Remove(bOOK_ISSUE);
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
