using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViennaRuns;

namespace ViennaRuns.Controllers
{
    public class RunsController : Controller
    {
        private ViennaRunsEntities db = new ViennaRunsEntities();
        

        // GET: Runs
        public ActionResult Index(string sortOrder, string sortType, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            var runs = db.Runs.Include(r => r.FeelingAfterRun).Include(r => r.User).Where(r => r.r_user == User.Identity.Name);
            switch (sortType)
            {
                case "date":
                    ViewBag.DateSortParm = sortOrder == "date" ? "date_asc" : "date";
                    break;
                case "duration":
                    ViewBag.DurationSortParm = sortOrder == "duration" ? "duration_asc" : "duration";
                    break;
                case "distance":
                    ViewBag.DistanceSortParm = sortOrder == "distance" ? "distance_asc" : "distance";
                    break;
                case "far":
                    ViewBag.FarSortParm = sortOrder == "far" ? "far_asc" : "far";
                    break;

            }
           
            switch (sortOrder)
            {
                case "date":
                    runs = runs.OrderByDescending(r => r.r_date);
                    break;
                case "date_asc":
                    runs = runs.OrderBy(r => r.r_date);
                    break;
                case "duration":
                    runs = runs.OrderByDescending(r => r.r_duration);
                    break;
                case "duration_asc":
                    runs = runs.OrderBy(r => r.r_duration);
                    break;
                case "distance":
                    runs = runs.OrderByDescending(r => r.r_distance);
                    break;
                case "distance_asc":
                    runs = runs.OrderBy(r => r.r_distance);
                    break;
                case "far":
                    runs = runs.OrderByDescending(r => r.r_datfeel);
                    break;
                case "far_asc":
                    runs = runs.OrderBy(r => r.r_datfeel);
                    break;
                default:
                    runs = runs.OrderByDescending(r => r.r_id);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var a = runs.ToPagedList(pageNumber, pageSize);
            return View(runs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Runs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // GET: Runs/Create
        public ActionResult Create()
        {
            ViewBag.r_datfeel = new SelectList(db.FeelingAfterRuns, "far_id", "far_datfeel");
            return View();
        }

        // POST: Runs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "r_id,r_distance,r_duration,r_date,r_datfeel")] Run run)
        {
            Console.WriteLine("CREATE RUN");
            if (ModelState.IsValid)
            {
                Console.WriteLine("Should add.");
                run.r_user = User.Identity.Name;
                db.Runs.Add(run);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.r_datfeel = new SelectList(db.FeelingAfterRuns, "far_id", "far_datfeel", run.r_datfeel);
            ViewBag.r_user = new SelectList(db.Users,"u_username","u_username",run.r_user);
            return View(run);
        }

        // GET: Runs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            ViewBag.r_datfeel = new SelectList(db.FeelingAfterRuns, "far_id", "far_datfeel", run.r_datfeel);
            ViewBag.r_user = new SelectList(db.Users, "u_username", "u_username", run.r_user);
            return View(run);
        }

        // POST: Runs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "r_id,r_distance,r_duration,r_date,r_datfeel")] Run run)
        {
            if (ModelState.IsValid)
            {
                run.r_user = User.Identity.Name;
                db.Entry(run).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.r_datfeel = new SelectList(db.FeelingAfterRuns, "far_id", "far_datfeel", run.r_datfeel);
            ViewBag.r_user = new SelectList(db.Users, "u_username", "u_username", run.r_user);
            return View(run);
        }

        // GET: Runs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Run run = db.Runs.Find(id);
            if (run == null)
            {
                return HttpNotFound();
            }
            return View(run);
        }

        // POST: Runs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Run run = db.Runs.Find(id);
            db.Runs.Remove(run);
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
