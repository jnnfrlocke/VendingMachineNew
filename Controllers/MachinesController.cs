using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Models;
using VendingMachineNew.Models;

namespace VendingMachineNew.Controllers
{
    public class MachinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Machines
        public ActionResult Index()
        {
            return View(db.Machines.ToList());
        }

        // GET: Machines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machines machines = db.Machines.Find(id);
            string url = this.Url.Action("Map", "Machines", null);
            string link = HttpContext.Request.Url.Scheme + "://" + /*HttpContext.Request.Url.Authority + Url.Action("Map", null, new { key = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJefLj_wsZBYgRbKc_1MALbaY&key=..." });*/

            if (machines == null)
            {
                return HttpNotFound();
            }
            return View(machines);
        }

        // GET: Machines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,City,State,ZipCode")] Machines machines)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machines);
        }

        // GET: Machines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machines machines = db.Machines.Find(id);
            if (machines == null)
            {
                return HttpNotFound();
            }
            return View(machines);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,City,State,ZipCode")] Machines machines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machines);
        }

        // GET: Machines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machines machines = db.Machines.Find(id);
            if (machines == null)
            {
                return HttpNotFound();
            }
            return View(machines);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Machines machines = db.Machines.Find(id);
            db.Machines.Remove(machines);
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
