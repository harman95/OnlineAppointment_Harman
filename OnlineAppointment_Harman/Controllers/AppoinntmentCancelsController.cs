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
    public class AppoinntmentCancelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppoinntmentCancels
        public ActionResult Index()
        {
            var appointmentCancels = db.AppointmentCancels.Include(a => a.Appointment);
            return View(appointmentCancels.ToList());
        }

        // GET: AppoinntmentCancels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppoinntmentCancel appoinntmentCancel = db.AppointmentCancels.Find(id);
            if (appoinntmentCancel == null)
            {
                return HttpNotFound();
            }
            return View(appoinntmentCancel);
        }

        // GET: AppoinntmentCancels/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID");
            return View();
        }

        // POST: AppoinntmentCancels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AppointmentID,CancelDate,Reason")] AppoinntmentCancel appoinntmentCancel)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentCancels.Add(appoinntmentCancel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID", appoinntmentCancel.AppointmentID);
            return View(appoinntmentCancel);
        }

        // GET: AppoinntmentCancels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppoinntmentCancel appoinntmentCancel = db.AppointmentCancels.Find(id);
            if (appoinntmentCancel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID", appoinntmentCancel.AppointmentID);
            return View(appoinntmentCancel);
        }

        // POST: AppoinntmentCancels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AppointmentID,CancelDate,Reason")] AppoinntmentCancel appoinntmentCancel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appoinntmentCancel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID", appoinntmentCancel.AppointmentID);
            return View(appoinntmentCancel);
        }

        // GET: AppoinntmentCancels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppoinntmentCancel appoinntmentCancel = db.AppointmentCancels.Find(id);
            if (appoinntmentCancel == null)
            {
                return HttpNotFound();
            }
            return View(appoinntmentCancel);
        }

        // POST: AppoinntmentCancels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppoinntmentCancel appoinntmentCancel = db.AppointmentCancels.Find(id);
            db.AppointmentCancels.Remove(appoinntmentCancel);
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
