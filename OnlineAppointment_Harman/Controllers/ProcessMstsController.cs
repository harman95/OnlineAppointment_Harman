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
    public class ProcessMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProcessMsts
        public ActionResult Index()
        {
            var processMsts = db.ProcessMsts.Include(p => p.Appointment);
            return View(processMsts.ToList());
        }

        // GET: ProcessMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMst processMst = db.ProcessMsts.Find(id);
            if (processMst == null)
            {
                return HttpNotFound();
            }
            return View(processMst);
        }

        // GET: ProcessMsts/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID");
            return View();
        }

        // POST: ProcessMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AppointmentID,ProcessDate,Remarks")] ProcessMst processMst)
        {
            if (ModelState.IsValid)
            {
                db.ProcessMsts.Add(processMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID", processMst.AppointmentID);
            return View(processMst);
        }

        // GET: ProcessMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMst processMst = db.ProcessMsts.Find(id);
            if (processMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID", processMst.AppointmentID);
            return View(processMst);
        }

        // POST: ProcessMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AppointmentID,ProcessDate,Remarks")] ProcessMst processMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentID = new SelectList(db.Appointments, "ID", "ID", processMst.AppointmentID);
            return View(processMst);
        }

        // GET: ProcessMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMst processMst = db.ProcessMsts.Find(id);
            if (processMst == null)
            {
                return HttpNotFound();
            }
            return View(processMst);
        }

        // POST: ProcessMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessMst processMst = db.ProcessMsts.Find(id);
            db.ProcessMsts.Remove(processMst);
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
