using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductivityTool.Data;

namespace ProductivityTool.Mvc.Controllers
{
    public class ActivitiesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Activities
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityType).Include(a => a.lkp_SizingUnit);
            return View(activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.FK_ActivityTypeID = new SelectList(db.ActivityTypes, "PK_ActivityTypeID", "ActivityType1");
            ViewBag.FK_SizingUnitID = new SelectList(db.lkp_SizingUnit, "PK_SizingUnitID", "SizingUnit");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_ActivityID,FK_ActivityTypeID,Activity1,FK_SizingUnitID")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ActivityTypeID = new SelectList(db.ActivityTypes, "PK_ActivityTypeID", "ActivityType1", activity.FK_ActivityTypeID);
            ViewBag.FK_SizingUnitID = new SelectList(db.lkp_SizingUnit, "PK_SizingUnitID", "SizingUnit", activity.FK_SizingUnitID);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ActivityTypeID = new SelectList(db.ActivityTypes, "PK_ActivityTypeID", "ActivityType1", activity.FK_ActivityTypeID);
            ViewBag.FK_SizingUnitID = new SelectList(db.lkp_SizingUnit, "PK_SizingUnitID", "SizingUnit", activity.FK_SizingUnitID);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_ActivityID,FK_ActivityTypeID,Activity1,FK_SizingUnitID")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ActivityTypeID = new SelectList(db.ActivityTypes, "PK_ActivityTypeID", "ActivityType1", activity.FK_ActivityTypeID);
            ViewBag.FK_SizingUnitID = new SelectList(db.lkp_SizingUnit, "PK_SizingUnitID", "SizingUnit", activity.FK_SizingUnitID);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
