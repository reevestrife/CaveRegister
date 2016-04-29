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
    public class VisitHistoriesController : Controller,IController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VisitHistories
		/// <summary>
		///  List All Visits according to the CaveID
		/// </summary>
		/// <param name="id">CaveID</param>
		/// <returns></returns>
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Index(int id)
        {
			var vm = new VisitHistoriesViewModel();
			vm.CaveID = id;
            return View(vm);
        }

		//vm.VisitHistories = db.VisitHistories.Where(p=> p.CaveID == id).Take(5);

        // GET: VisitHistories/Details/5
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            if (visitHistory == null)
            {
                return HttpNotFound();
            }
            return View(visitHistory);
        }

        // GET: VisitHistories/Create
		[Roles(Role.Admin, Role.Contributor)]
		public ActionResult Create(int id)
        {
			var vh = new VisitHistory();
			vh.CaveId = id;
			vh.VistitDate = DateTime.Now;
			db.VisitHistories.Add(vh);
			db.SaveChanges();

			return RedirectToAction("Edit", new {id= vh.VisitHistoryId });
        }

      

        // GET: VisitHistories/Edit/5
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var vm = new VisitHistoryViewModel();

            vm.VisitHistory = db.VisitHistories.Find(id);
            if (vm.VisitHistory == null)
            {
                return HttpNotFound();
            }

			vm.AttendingApplicationUsersSelectList = new SelectList(db.Users, "Id", "NameAndSurname");
			vm.SelectedAttendingApplicationUsers = vm.VisitHistory.AttendingApplicationUsers.Select(p => p.Id).ToList<string>();
            return View(vm);
        }

        // POST: VisitHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit(VisitHistoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var item = db.Entry<VisitHistory>(vm.VisitHistory);
				item.State = System.Data.Entity.EntityState.Modified;
				item.Collection(i => i.AttendingApplicationUsers).Load();

				vm.VisitHistory.AttendingApplicationUsers.Clear();
				foreach (var saau in vm.SelectedAttendingApplicationUsers)
				{
					var user = db.Users.Find(saau);
					vm.VisitHistory.AttendingApplicationUsers.Add(user);
				}

				//item.Collection(i => i.Observation).Load();	

                db.SaveChanges();
				return RedirectToAction("edit", "Caves", new { id = vm.VisitHistory.CaveId }).AddFragment("VisitHistorySection");
            }
			vm.AttendingApplicationUsersSelectList = new SelectList(db.Users, "Id", "UserName");
            return View(vm);
        }

        // GET: VisitHistories/Delete/5
		[Roles(Role.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            if (visitHistory == null)
            {
                return HttpNotFound();
            }
            return View(visitHistory);
        }

		public ActionResult ListVisitHistories(TableRequestModel request, VisitHistoriesViewModel model)
		{
			IQueryable<VisitHistory> vh = db.VisitHistories.Where(p => p.CaveId == model.CaveID);
			return TableResult.From(vh).Build<VisitHistoryTable>(request);
		}


        // POST: VisitHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            db.VisitHistories.Remove(visitHistory);
            db.SaveChanges();
			return RedirectToAction("edit", "Caves", new { id = visitHistory.CaveId }).AddFragment("VisitHistorySection");
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
