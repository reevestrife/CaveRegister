using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaveRegister.Models;
using CaveRegister.EF;
using CaveRegister.Attributes;
using CaveRegister.Model;

namespace CaveRegister.Controllers
{
	[Authorize]
    public class PublicationEntitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PublicationEntities
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Index()
        {
            return View(db.PublicationEntities.ToList());
        }

        // GET: PublicationEntities/Details/5
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationEntity publicationEntity = db.PublicationEntities.Find(id);
            if (publicationEntity == null)
            {
                return HttpNotFound();
            }
            return View(publicationEntity);
        }

        // GET: PublicationEntities/Create
		[Roles(Role.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicationEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin)]
        public ActionResult Create([Bind(Include = "PublicationEntityID,Description")] PublicationEntity publicationEntity)
        {
            if (ModelState.IsValid)
            {
                db.PublicationEntities.Add(publicationEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicationEntity);
        }

        // GET: PublicationEntities/Edit/5
		[Roles(Role.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationEntity publicationEntity = db.PublicationEntities.Find(id);
            if (publicationEntity == null)
            {
                return HttpNotFound();
            }
            return View(publicationEntity);
        }

        // POST: PublicationEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[Roles(Role.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublicationEntityID,Description")] PublicationEntity publicationEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicationEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicationEntity);
        }

        // GET: PublicationEntities/Delete/5
		[Roles(Role.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicationEntity publicationEntity = db.PublicationEntities.Find(id);
            if (publicationEntity == null)
            {
                return HttpNotFound();
            }
            return View(publicationEntity);
        }

        // POST: PublicationEntities/Delete/5
		[Roles(Role.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicationEntity publicationEntity = db.PublicationEntities.Find(id);
            db.PublicationEntities.Remove(publicationEntity);
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
