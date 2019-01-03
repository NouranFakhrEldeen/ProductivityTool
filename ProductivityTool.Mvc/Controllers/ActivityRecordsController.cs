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
    public class ActivityRecordsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ActivityRecords
        public ActionResult Index()
        {
            var activityRecords = db.ActivityRecords.Include(a => a.Activity).Include(a => a.Demand).Include(a => a.Project);
            return View(activityRecords.ToList());
        }

        // GET: ActivityRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            if (activityRecord == null)
            {
                return HttpNotFound();
            }
            return View(activityRecord);
        }

        // GET: ActivityRecords/Create
        public ActionResult Create()
        {
            ViewBag.ActivityID = new SelectList(db.Activities, "Id", "Name");
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "DemandType");
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "ProjectName");
            return View();
        }

        // POST: ActivityRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "Id,ActivityDate,ActivityID,DemandID,ProjectID,Size,ActualEffort_Hours,Comment")] ActivityRecord activityRecord)
        {
            if (ModelState.IsValid)
            {
                db.ActivityRecords.Add(activityRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityID = new SelectList(db.Activities, "Id", "Name", activityRecord.ActivityID);
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "DemandType", activityRecord.DemandID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "ProjectName", activityRecord.ProjectID);
            return View(activityRecord);
        }

        // GET: ActivityRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            if (activityRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "Id", "Name", activityRecord.ActivityID);
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "DemandType", activityRecord.DemandID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "ProjectName", activityRecord.ProjectID);
            return View(activityRecord);
        }

        // POST: ActivityRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,ActivityDate,ActivityID,DemandID,ProjectID,Size,ActualEffort_Hours,Comment")] ActivityRecord activityRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "Id", "Name", activityRecord.ActivityID);
            ViewBag.DemandID = new SelectList(db.Demands, "Id", "DemandType", activityRecord.DemandID);
            ViewBag.ProjectID = new SelectList(db.Projects, "Id", "ProjectName", activityRecord.ProjectID);
            return View(activityRecord);
        }

        // GET: ActivityRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            if (activityRecord == null)
            {
                return HttpNotFound();
            }
            return View(activityRecord);
        }

        // POST: ActivityRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityRecord activityRecord = db.ActivityRecords.Find(id);
            db.ActivityRecords.Remove(activityRecord);
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
