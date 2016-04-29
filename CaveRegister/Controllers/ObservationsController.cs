using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaveRegister.Models;
using CaveRegister.EF;
using CaveRegister.Models;
using CaveRegister.Attributes;
using MvcTables;
using CaveRegister.MVCTableModels;
using CaveRegister.Helpers;
using CaveRegister.Model;

namespace CaveRegister.Controllers
{
    public class ObservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Observation
		/// <summary>
		/// Observed life in Cave for VisitHistoryID
		/// </summary>
		/// <param name="Id">VisitHistoryID</param>
		/// <returns></returns>
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Index(int Id)
        {
			var vm = new ObservationsModel();
			vm.VisitHistoryID = Id;
            return View(vm);
        }

        // GET: Observation/Details/5
		public ActionResult Details(int visitHistoryID, int observableEntityID)
        {
            Observation observation = db.Observations.Find(observableEntityID,visitHistoryID);
            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);
        }

        // GET: Observation/Create
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">VisitHistoryID</param>
		/// <returns></returns>
        public ActionResult Create(int id)
        {
			var vm = new ObservationViewModel(db,null);
			vm.Model = new Observation();
			vm.Model.VisitHistory = db.VisitHistories.Find(id);
			vm.Model.VisitHistoryId = id;
            return View(vm);
        }

        // POST: Observation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObservationViewModel vm)
        {
            if (ModelState.IsValid)
            {
				vm.Initialise(db);
				vm.PrepareSave();
				db.Observations.Add(vm.Model);
                db.SaveChanges();
				return RedirectToAction("edit", "VisitHistories", new { id = vm.Model.VisitHistoryId }).AddFragment("ObservationsSection");
            }
			vm.ObservableEntitySelectList = new SelectList(db.ObservableEntities, "ObservableEntityID", "Name");
            return View(vm);
        }

        // GET: Observation/Edit/5
        public ActionResult Edit(int? visitHistoryID,int? observableEntityID)
        {
			if (visitHistoryID == null || observableEntityID == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			//var vm = new ObservationViewModel();
			var observation = db.Observations.Find(observableEntityID, visitHistoryID);
			if (observation == null)
            {
                return HttpNotFound();
            }
			ObservationViewModel vm = new ObservationViewModel(db, observation);
            return View(vm);
        }

        // POST: Observation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ObservationViewModel vm)
        {
            if (ModelState.IsValid)
            {
				var item = db.Entry(vm.Model);
				item.State = EntityState.Modified;
				vm.Initialise(db);
				vm.PrepareSave();
                db.SaveChanges();
				return RedirectToAction("edit", "VisitHistories", new { id = vm.Model.VisitHistoryId }).AddFragment("ObservationSection");
            }
			vm.PopulateSelectLists();
            return View(vm);
        }

        // GET: Observation/Delete/5
		public ActionResult Delete(int visitHistoryID, int observableEntityID)
        {
			Observation observation = db.Observations.Find(observableEntityID, visitHistoryID);
            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);
        }

        // POST: Observation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int visitHistoryID, int observableEntityID)
        {
			Observation observation = db.Observations.Find(observableEntityID,visitHistoryID);
            db.Observations.Remove(observation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public ActionResult ListObservation(TableRequestModel request, ObservationsModel model)
		{
			var observations = db.Observations.Where(p => p.VisitHistoryId == model.VisitHistoryID);
			return TableResult.From(observations).Build<ObservationTable>(request);
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
