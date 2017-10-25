using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Models;

namespace VendingMachineNew.Controllers
{
    public class InventoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inventories
        public ActionResult Index()
        {
            var itemType = db.Inventories.ToList();
            return View(itemType);
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int id)
        {
            var itemType = db.Inventories.SingleOrDefault(m => m.id == id);
            return View(itemType);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            Inventory inventory = new Inventory();

            return View(inventory);
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory)
        {

            if (inventory.id == 0)
            {
                db.SaveChanges();
                db.Inventories.Add(inventory);
            }
            else
            {
                var itemInDB = db.Inventories.Single(m => m.id == inventory.id);
                itemInDB.typeProduct = inventory.typeProduct;
                itemInDB.name = inventory.name;
                itemInDB.quantity = inventory.quantity;
                itemInDB.price = inventory.price;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Inventory");
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory inventory)
        {
            var itemInDB = db.Inventories.Single(m => m.id == inventory.id);
            itemInDB.typeProduct = inventory.typeProduct;
            itemInDB.name = inventory.name;
            itemInDB.quantity = inventory.quantity;
            itemInDB.price = inventory.price;
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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

