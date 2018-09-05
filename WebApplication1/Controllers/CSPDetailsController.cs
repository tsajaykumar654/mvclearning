using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class CSPDetailsController : Controller
    {
        private MVCAppDatabaseEntities db = new MVCAppDatabaseEntities();

        // GET: CSPDetails
        public ActionResult Index()
        {
            return View(db.CSPDetails.ToList());
        }

        // GET: CSPDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSPDetail cSPDetail = db.CSPDetails.Find(id);
            if (cSPDetail == null)
            {
                return HttpNotFound();
            }
            return View(cSPDetail);
        }

        // GET: CSPDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CSPDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserId,Name,CreateDate,Finger1,Finger2,Finger3,Finger4,IsDeleted,UserTypeId")] CSPDetail cSPDetail)
        {
            if (ModelState.IsValid)
            {
                db.CSPDetails.Add(cSPDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cSPDetail);
        }

        // GET: CSPDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSPDetail cSPDetail = db.CSPDetails.Find(id);
            if (cSPDetail == null)
            {
                return HttpNotFound();
            }
            return View(cSPDetail);
        }

        // POST: CSPDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserId,Name,CreateDate,Finger1,Finger2,Finger3,Finger4,IsDeleted,UserTypeId")] CSPDetail cSPDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSPDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cSPDetail);
        }

        // GET: CSPDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSPDetail cSPDetail = db.CSPDetails.Find(id);
            if (cSPDetail == null)
            {
                return HttpNotFound();
            }
            return View(cSPDetail);
        }

        // POST: CSPDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSPDetail cSPDetail = db.CSPDetails.Find(id);
            db.CSPDetails.Remove(cSPDetail);
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
