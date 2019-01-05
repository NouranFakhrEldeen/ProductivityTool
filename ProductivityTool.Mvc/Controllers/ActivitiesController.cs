using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProductivityTool.Mvc.Models;
using ProductivityTool.Data;
using System.Collections.Generic;
using System.Net;
using System.Data.Entity;

namespace ProductivityTool.Mvc.Controllers
{
    public class ActivitiesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Activities
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityType);
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
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "ID", "Name");
            //List<SelectListItem> test = new List<SelectListItem>();
            //test.Add(new SelectListItem
            //{
            //    Text = "Demand",
            //    Value = "1"
            //});
            //ViewBag.ActivityType.ActivityCategory = test;
            
            List<ActivityCategory> c = db.ActivityCategories.ToList();

            ViewBag.ActivityCategory = new SelectList(db.ActivityCategories, "Id", "Name");


            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "ID", "Name", activity.ActivityTypeId);
            ViewBag.ActivityType.ActivityCategoryId = new SelectList(db.ActivityCategories, "ID", "Name", activity.ActivityType.ActivityCategoryId);
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
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "ID", "Name", activity.ActivityTypeId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "Id,Name,SizingUnitID,ActivityTypeId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "ID", "Name", activity.ActivityTypeId);
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

        //private Activity getList()
        //{
        //    var result = new SelectList(db.ActivityCategories.Select(r => new
        //    {
        //        Value = r.Id,
        //        Text = r.Name
        //    }), "Value", "Text").ToList();

        //    //var model = new Activity();
        //    //model.ActivityType.ActivityCategory = result;

        //    var model = new Activity();

        //    model.ActivityType.ActivityCategory = result;
        //    return model;

        //}


        [HttpPost]
        public ActionResult GetByCategory(int id)
        {
            var result = db.ActivityTypes.Select(r => new typePOCP { ID = r.ID, Name = r.Name}).Where(r => r.ID == id).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
