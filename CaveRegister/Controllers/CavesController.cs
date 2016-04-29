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
using MvcTables;
using CaveRegister.MVCTableModels;
using CaveRegister.Helpers;
using CaveRegister.Attributes;
using CaveRegister.Model;

namespace CaveRegister.Controllers
{
	[Authorize]
    public class CavesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Caves
		[Roles(Role.Admin,Role.Contributor,Role.Observer)]
        public ActionResult Index()
        {
			var filteredCavesVM = new FilteredCavesViewModel();
			var LookupRepository = new LookupRepository(db);
			filteredCavesVM.HideCodelessItems = true;
			filteredCavesVM.ExplorationStatusSelectList = new SelectList(LookupRepository.ExplorationStatuses, "ExplorationStatusID", "Description");
			filteredCavesVM.LocationStatusSelectList = new SelectList(LookupRepository.LocationStatuses, "LocationStatusID", "Description");
			//filteredCavesVM.ProvincesSelectList = new SelectList(LookupRepository.ProvinceList, "ProvinceID", "Description");
			filteredCavesVM.CaveStatusSelectList = new SelectList(LookupRepository.CaveStatuses, "CaveStatusID", "Description");
			filteredCavesVM.CaveAttributeSelectList = new SelectList(LookupRepository.CaveAttributes, "CaveAttributeID", "Description");


			filteredCavesVM.Caves =db.Caves.Include(c => c.ExplorationStatus).Include(c => c.LocationStatus).Include(c => c.Province).Take(10);
			return View(filteredCavesVM);
        }

        // GET: Caves/Details/5
		[Roles(Role.Admin,Role.Contributor,Role.Observer)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cave cave = db.Caves.Find(id);
            if (cave == null)
            {
                return HttpNotFound();
            }
            return View(cave);
        }

        // GET: Caves/Create
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Create()
        {
			CaveViewModel caveVM = new CaveViewModel(db,null);
			return View(caveVM);
        }

        // POST: Caves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
		public ActionResult Create(CaveViewModel vm) //[Bind(Include = "CaveID,SasaCode,Name,Description,Folder,Reference,TotalExtension,Depth,ProvinceID,Location,Longitude,Latitude,DbGeography_Location,Elevation,LandOwnerName,LandOwnerPhone,LandOwnerEmail,LandOwnerLongitude,LandOwnerLatitude,DbGeography_LandOwner,LandOwnerDetails,Geology,DateDiscovered,ExplorationStatusID,LocationStatusID,IsWaterInCave,IsShrimpInCave,IsInsectLifeInCave,IsBatsInCave,IsFishInCave,IsFossilsInCave,IsBobsCavesCanidate,LastEditDate,DateCreated,IsDeleted")]
        {
            if (ModelState.IsValid)
            {
				vm.Initialise(db);
				vm.PrepareSave();
                db.Caves.Add(vm.Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			vm.PopulateSelectLists();

            return View(vm);
        }

        // GET: Caves/Edit/5
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cave cave = db.Caves.Find(id);
            if (cave == null)
            {
                return HttpNotFound();
            }
			CaveViewModel caveVM = new CaveViewModel(db,cave);
            return View(caveVM);
        }

        // POST: Caves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
		public ActionResult Edit(CaveViewModel vm) // [Bind(Include = "CaveID,SasaCode,Name,Description,Folder,Reference,TotalExtension,Depth,ProvinceID,Location,Longitude,Latitude,DbGeography_Location,Elevation,LandOwnerName,LandOwnerPhone,LandOwnerEmail,LandOwnerLongitude,LandOwnerLatitude,DbGeography_LandOwner,LandOwnerDetails,Geology,DateDiscovered,ExplorationStatusID,LocationStatusID,IsWaterInCave,IsShrimpInCave,IsInsectLifeInCave,IsBatsInCave,IsFishInCave,IsFossilsInCave,IsBobsCavesCanidate,LastEditDate,DateCreated,IsDeleted")] 
        {
            if (ModelState.IsValid)
            {
				var item = db.Entry(vm.Model);
				//var item = db.Entry<Cave>(caveVM.Model);
				item.State = System.Data.Entity.EntityState.Modified;
				vm.Initialise(db);

				//item.Collection(i => i.CaveAttributes).Load();
				//item.Collection(i => i.CaveStatuses).Load();
				//item.Collection(i => i.EaseOfAccesses).Load();
				//item.Collection(i => i.Geologies).Load();

				item.Collection("CaveAttributes").Load();
				item.Collection("CaveStatuses").Load();
				item.Collection("EaseOfAccesses").Load();
				item.Collection("Geologies").Load();


				vm.PrepareSave();

				//item.Collection(i => i.CaveStatuses).Load();
				//caveVM.Model.CaveStatuses.Clear();
				
				//foreach (var scs in caveVM.SelectedCaveStatuses)
				//{
				//	//var status = LookupRepository.CaveStatusList.Single(p=> p.CaveStatusID == scs);
				//	var asd = db.CaveStatuses.Find(scs);
				//	caveVM.Model.CaveStatuses.Add(asd);
				//}

                db.SaveChanges();
                return RedirectToAction("Index");
            }
			//caveVM.ExplorationStatusSelectList = new SelectList(LookupRepository.ExplorationStatusList, "ExplorationStatusID", "Description", caveVM.Model.ExplorationStatusID);
			//caveVM.LocationStatusSelectList = new SelectList(LookupRepository.LocationStatusList, "LocationStatusID", "Description", caveVM.Model.LocationStatusID);
			//caveVM.ProvincesSelectList = new SelectList(LookupRepository.ProvinceList, "ProvinceID", "Description", caveVM.Model.ProvinceID);
			//caveVM.CaveStatusSelectList = new SelectList(LookupRepository.CaveStatusList, "CaveStatusID", "Description");
			//caveVM.CaveAttributeSelectList = new SelectList(LookupRepository.CaveAttributeList, "CaveAttributeID", "Description");
			//caveVM.Model.PopulateRelatedEntitesFromIDs();
			vm.PopulateSelectLists();

            return View(vm);
        }

        // GET: Caves/Delete/5
		[Roles(Role.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cave cave = db.Caves.Find(id);
            if (cave == null)
            {
                return HttpNotFound();
            }
            return View(cave);
        }

        // POST: Caves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            Cave cave = db.Caves.Find(id);
            db.Caves.Remove(cave);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public ActionResult ListCavesForFilters(TableRequestModel request, FilteredCavesViewModel model)
		{
			request.PageSize = request.PageSize ?? 10;
			//var caves = db.Caves;
			IQueryable<Cave> caves = db.Caves;
			//var mainPredicate = PredicateBuilder.True<Cave>();
			if(model.HideCodelessItems)
			{
				caves = caves.Where(p => p.SasaCode != null);
			}
			if(!string.IsNullOrEmpty(model.SearchText))
			{
				caves = caves.Where(p => p.Name.Contains(model.SearchText) || p.Description.Contains(model.SearchText));
			}
			if(!string.IsNullOrEmpty(model.SelectedCaveAttributes))
			{
				//var attributePredicate = PredicateBuilder.True<Cave>();
				var caveAttributeList = model.SelectedCaveAttributes.Split(',').ToList();
				foreach (var item in caveAttributeList.Where(p => p != "null"))
				{
					caves = caves.Where(p => p.CaveAttributes.Any(x => x.CaveAttributeId == item));
					//attributePredicate = attributePredicate.Or(p=> p.CaveAttributes.Contains(new CaveAttribute(){CaveAttributeID = item}));
				}
				//mainPredicate = mainPredicate.And(attributePredicate);
			}
			if (!string.IsNullOrEmpty(model.SelectedCaveStatuses))
			{
				var caveStatusList = model.SelectedCaveStatuses.Split(',').ToList();

				
				foreach (var item in caveStatusList.Where(p=> p != "null"))
				{
					caves = caves.Where(p=> p.CaveStatuses.Any(x=> x.CaveStatusId == item ));
					//statusPredicate = statusPredicate.Or(p => p.CaveStatuses.Any(x=> x.CaveStatusID == item));
				}
				//caves = caves.Where(statusPredicate);
				//mainPredicate = mainPredicate.And(statusPredicate);
			}
			if (!string.IsNullOrEmpty(model.SelectedExplorationStatus))
			{
				caves = caves.Where(p => p.ExplorationStatusId == model.SelectedExplorationStatus);
			}
			if (!string.IsNullOrEmpty(model.SelectedLocationStatus))
			{
				//mainPredicate.And(p => p.LocationStatusID == model.SelectedLocationStatus);
				caves = caves.Where(p => p.LocationStatusId == model.SelectedLocationStatus);
			}
			
			//if (!String.IsNullOrEmpty(model.SelectedCustomerId))
			//{
			//	orders = orders.Where(o => o.CustomerID == model.SelectedCustomerId);
			//}
			//caves = caves.Where(mainPredicate);

			//var mycaves = caves.ToList();
			return TableResult.From(caves).Build<CaveFilterTable>(request);
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
