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
        public ActionResult Index()
        {
            var runs = db.Runs.Include(r => r.FeelingAfterRun).Include(r => r.User);
            return View(runs.ToList());
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
            ViewBag.r_user = new SelectList(db.Users, "u_username", "u_username");
            return View();
        }

        // POST: Runs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "r_id,r_user,r_distance,r_duration,r_date,r_datfeel")] Run run)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "r_id,r_user,r_distance,r_duration,r_date,r_datfeel")] Run run)
        {
            if (ModelState.IsValid)
            {
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
