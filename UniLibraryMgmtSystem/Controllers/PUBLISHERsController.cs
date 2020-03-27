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
    public class PUBLISHERsController : Controller
    {
        private LibraryManagementSystemEntities db = new LibraryManagementSystemEntities();

        // GET: PUBLISHERs
        public ActionResult Index()
        {
            var pUBLISHERs = db.PUBLISHERs.Include(p => p.PublicationType);
            return View(pUBLISHERs.ToList());
        }

        // GET: PUBLISHERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Create
        public ActionResult Create()
        {
            ViewBag.PublicationTypeId = new SelectList(db.PublicationTypes, "ID", "NAME");
            return View();
        }

        // POST: PUBLISHERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PublicationTypeId,NAME,ADDRESS,EMAIL,CONTACT_NO")] PUBLISHER pUBLISHER)
        {
            if (ModelState.IsValid)
            {
                db.PUBLISHERs.Add(pUBLISHER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PublicationTypeId = new SelectList(db.PublicationTypes, "ID", "NAME", pUBLISHER.PublicationTypeId);
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublicationTypeId = new SelectList(db.PublicationTypes, "ID", "NAME", pUBLISHER.PublicationTypeId);
            return View(pUBLISHER);
        }

        // POST: PUBLISHERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PublicationTypeId,NAME,ADDRESS,EMAIL,CONTACT_NO")] PUBLISHER pUBLISHER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUBLISHER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PublicationTypeId = new SelectList(db.PublicationTypes, "ID", "NAME", pUBLISHER.PublicationTypeId);
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // POST: PUBLISHERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            db.PUBLISHERs.Remove(pUBLISHER);
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
