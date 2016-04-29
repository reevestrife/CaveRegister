using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CaveRegister.Models;
using CaveRegister.Attributes;

using CaveRegister.Model;

namespace CaveRegister.Controllers
{
	[Roles(Role.Admin)]
    public class ObservableEntitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ObservableEntities
        public ActionResult Index()
        {
            return View(db.ObservableEntities.ToList());
        }

        // GET: ObservableEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			ObservableEntity observableEntity = db.ObservableEntities.Find(id);
            if (observableEntity == null)
            {
                return HttpNotFound();
            }
            return View(observableEntity);
        }
		 
        // GET: ObservableEntities/Create
        public ActionResult Create()
        {
			var vm = new ObservableEntityViewModel(db, null);
            return View(vm);
        }

        // POST: ObservableEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObservableEntityViewModel vm)
        {
            if (ModelState.IsValid)
            {
				vm.Initialise(db);
				vm.PrepareSave();
                db.ObservableEntities.Add(vm.Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			vm.PopulateSelectLists();
            return View(vm);
        }

        // GET: ObservableEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservableEntity observableEntity = db.ObservableEntities.Find(id);
            if (observableEntity == null)
            {
                return HttpNotFound();
            }
			var vm = new ObservableEntityViewModel(db, observableEntity);
            return View(vm);
        }

		// POST: ObservableEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit(ObservableEntityViewModel vm) //[Bind(Include = "ObservableEntityID,Name,ScientificName")]
        {
            if (ModelState.IsValid)
            {
				var item = db.Entry(vm.Model);
				item.State = EntityState.Modified;
				vm.Initialise(db);

				item.Collection("ObservableEntityTypes").Load();

				vm.PrepareSave();
				//var existingObservableEntity = db.ObservableEntities.Find(observableEntity.ObservableEntityID);
				//existingObservableEntity.Name = observableEntity.Name;
				//existingObservableEntity.ScientificName = observableEntity.ScientificName;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			vm.PopulateSelectLists();

            return View(vm);
        }

		// GET: ObservableEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			ObservableEntity observableEntity = db.ObservableEntities.Find(id);
            if (observableEntity == null)
            {
                return HttpNotFound();
            }
            return View(observableEntity);
        }

        // POST: ObservableEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			ObservableEntity observableEntity = db.ObservableEntities.Find(id);
			db.ObservableEntities.Remove(observableEntity);
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
