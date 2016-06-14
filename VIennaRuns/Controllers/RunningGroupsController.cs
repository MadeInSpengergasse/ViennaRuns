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
    public class RunningGroupsController : Controller
    {
        private ViennaRunsEntities db = new ViennaRunsEntities();

        // GET: RunningGroups
        public ActionResult Index()
        {
            return View(db.RunningGroups.ToList());
        }

        // GET: RunningGroups/Details/5
        public ActionResult Details(int? id)
        {
            var aspsucks = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunningGroup runningGroup = db.RunningGroups.Find(id);
            if (runningGroup == null)
            {
                return HttpNotFound();
            }
            if(db.Users.SingleOrDefault(a => a.u_username == User.Identity.Name).u_runninggroup != null)
            {
                runningGroup.rg_id = -1;
            }
            return View(runningGroup);
        }

        // GET: RunningGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RunningGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rg_name")] RunningGroup runningGroup)
        {
            if (ModelState.IsValid)
            {
                db.RunningGroups.Add(runningGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(runningGroup);
        }

        // GET: RunningGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunningGroup runningGroup = db.RunningGroups.Find(id);
            if (runningGroup == null)
            {
                return HttpNotFound();
            }
            return View(runningGroup);
        }

        // POST: RunningGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rg_name,rg_id")] RunningGroup runningGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(runningGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(runningGroup);
        }

        // GET: RunningGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RunningGroup runningGroup = db.RunningGroups.Find(id);
            if (runningGroup == null)
            {
                return HttpNotFound();
            }
            return View(runningGroup);
        }

        // POST: RunningGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RunningGroup runningGroup = db.RunningGroups.Find(id);
            db.RunningGroups.Remove(runningGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult JoinGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = db.Users.SingleOrDefault(b => b.u_username == User.Identity.Name);
            result.u_runninggroup = id;
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
