using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaveRegister.Models;
using CaveRegister.EF;
using CaveRegister.Helpers;
using CaveRegister.Model;

namespace CaveRegister.Controllers
{
    public class EntrancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Entrances
        public ActionResult Index(int id)
        {
			ViewBag.id = id;
            var entrances = db.Entrances.Where(p=> p.CaveId  == id);
            return View(entrances.ToList());
        }

        // GET: Entrances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        // GET: Entrances/Create
        public ActionResult Create(int id)
        {
			var entr = new Entrance();
			entr.CaveId = id;
            return View(entr);
        }

        // POST: Entrances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntranceID,CaveID,GeoLocation,Altitude,Name")] Entrance entrance)
        {
            if (ModelState.IsValid)
            {
                db.Entrances.Add(entrance);
                db.SaveChanges();
				return RedirectToAction("edit", "Caves", new { id = entrance.CaveId }).AddFragment("EntranceSection");
            }
            
            return View(entrance);
        }

        // GET: Entrances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        // POST: Entrances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntranceID,CaveID,GeoLocation,Altitude,Name,FileID,LastEditDate,DateCreated,IsDeleted,LasEditApplicationUserID,EntityStatusID,WorkflowID")] Entrance entrance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrance).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
				return RedirectToAction("edit", "Caves", new { id = entrance.CaveId }).AddFragment("EntranceSection");
            }
            return View(entrance);
        }

        // GET: Entrances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrance entrance = db.Entrances.Find(id);
            if (entrance == null)
            {
                return HttpNotFound();
            }
            return View(entrance);
        }

        // POST: Entrances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrance entrance = db.Entrances.Find(id);
            db.Entrances.Remove(entrance);
            db.SaveChanges();
			return RedirectToAction("edit", "Caves", new { id = entrance.CaveId }).AddFragment("EntranceSection");
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
