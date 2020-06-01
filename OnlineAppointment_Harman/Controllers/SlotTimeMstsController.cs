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
    public class SlotTimeMstsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SlotTimeMsts
        public ActionResult Index()
        {
            return View(db.SlotTimeMsts.ToList());
        }

        // GET: SlotTimeMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlotTimeMst slotTimeMst = db.SlotTimeMsts.Find(id);
            if (slotTimeMst == null)
            {
                return HttpNotFound();
            }
            return View(slotTimeMst);
        }

        // GET: SlotTimeMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlotTimeMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SlotDateTime")] SlotTimeMst slotTimeMst)
        {
            if (ModelState.IsValid)
            {
                db.SlotTimeMsts.Add(slotTimeMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slotTimeMst);
        }

        // GET: SlotTimeMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlotTimeMst slotTimeMst = db.SlotTimeMsts.Find(id);
            if (slotTimeMst == null)
            {
                return HttpNotFound();
            }
            return View(slotTimeMst);
        }

        // POST: SlotTimeMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SlotDateTime")] SlotTimeMst slotTimeMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slotTimeMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slotTimeMst);
        }

        // GET: SlotTimeMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlotTimeMst slotTimeMst = db.SlotTimeMsts.Find(id);
            if (slotTimeMst == null)
            {
                return HttpNotFound();
            }
            return View(slotTimeMst);
        }

        // POST: SlotTimeMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SlotTimeMst slotTimeMst = db.SlotTimeMsts.Find(id);
            db.SlotTimeMsts.Remove(slotTimeMst);
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
