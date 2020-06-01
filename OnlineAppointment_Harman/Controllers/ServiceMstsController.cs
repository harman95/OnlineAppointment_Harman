using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineAppointment_Harman.Models;

namespace OnlineAppointment_Harman.Controllers
{
    [Authorize]
    public class ServiceMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceMsts
        public ActionResult Index()
        {
            return View(db.ServiceMsts.ToList());
        }

        // GET: ServiceMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceMst serviceMst = db.ServiceMsts.Find(id);
            if (serviceMst == null)
            {
                return HttpNotFound();
            }
            return View(serviceMst);
        }

        // GET: ServiceMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ServiceName")] ServiceMst serviceMst)
        {
            if (ModelState.IsValid)
            {
                db.ServiceMsts.Add(serviceMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceMst);
        }

        // GET: ServiceMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceMst serviceMst = db.ServiceMsts.Find(id);
            if (serviceMst == null)
            {
                return HttpNotFound();
            }
            return View(serviceMst);
        }

        // POST: ServiceMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ServiceName")] ServiceMst serviceMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceMst);
        }

        // GET: ServiceMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceMst serviceMst = db.ServiceMsts.Find(id);
            if (serviceMst == null)
            {
                return HttpNotFound();
            }
            return View(serviceMst);
        }

        // POST: ServiceMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceMst serviceMst = db.ServiceMsts.Find(id);
            db.ServiceMsts.Remove(serviceMst);
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
