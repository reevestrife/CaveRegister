using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaveRegister.Models;
using CaveRegister.EF;
using MvcTables;
using CaveRegister.MVCTableModels;
using CaveRegister.Models;
using CaveRegister.Attributes;
using CaveRegister.Helpers;
using CaveRegister.Model;

namespace CaveRegister.Controllers
{
    public class CaveFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CaveFiles
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Index(int id)
        {

			if (id == 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var caveFilesModel = new CaveFilesModel();
			caveFilesModel.CaveID = id;
			caveFilesModel.CaveFiles = db.Caves.Find(id).MetaFiles.Take(5);
            return View(caveFilesModel);
        }

     

        // GET: CaveFiles/Create
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Create(int id)
        {
			if (id == 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			CaveFileViewModel vm = new CaveFileViewModel();
			vm.CaveID = id;
			vm.FileTypeSelectList = new SelectList(db.FileTypes, "FileTypeID", "Description");
            return View(vm);
        }

        // POST: CaveFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Create(CaveFileViewModel vm)
        {
            if (ModelState.IsValid)
            {
				db.Caves.Find(vm.CaveID).MetaFiles.Add(PopulateCaveFileFromVM(vm));
                db.SaveChanges();
				return RedirectToAction("edit", "Caves", new { id = vm.CaveID }).AddFragment("CaveFilesSection");
            }
			vm.FileTypeSelectList = new SelectList(db.FileTypes, "FileTypeID", "Description",vm.FileTypeID);
            return View(vm);
        }

		private MetaFile PopulateCaveFileFromVM(CaveFileViewModel vm)
		{
			File file = new File();
			SetFileFromVM(file, vm);

			MetaFile caveFile = new MetaFile();
			caveFile.File = file;

			caveFile.FileType = db.FileTypes.Find(vm.FileTypeID);
			caveFile.FileTypeId = vm.FileTypeID;

			caveFile.Description = vm.Description;

			db.Caves.Find(vm.CaveID).MetaFiles.Add(caveFile);
			return caveFile;
		}



		private void SetFileFromVM(File file, CaveFileViewModel vm)
		{
			if (vm.Data != null)
			{
				using (var memoryStream = new System.IO.MemoryStream())
				{
					vm.Data.InputStream.CopyTo(memoryStream);
					file.Data = memoryStream.ToArray();
				}
				file.FileName = vm.Data.FileName;
				file.MimeType = vm.Data.ContentType;
			}
		}

        // GET: CaveFiles/Edit/5
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			MetaFile caveFile = db.MetaFiles.Find(id);
            if (caveFile == null)
            {
                return HttpNotFound();
            }

			CaveFileViewModel vm = new CaveFileViewModel();
			//vm.CaveID = caveFile.CaveID;
			vm.FileID = caveFile.FileId;
			vm.Description = caveFile.Description;
			vm.FileTypeID = vm.FileTypeID;
			vm.FileTypeSelectList = new SelectList(db.FileTypes, "FileTypeID", "Description", caveFile.FileTypeId);  
            return View(vm);
        }

        // POST: CaveFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit(CaveFileViewModel vm)
        {
            if (ModelState.IsValid)
            {
				MetaFile caveFile = db.MetaFiles.Find(vm.FileID);
				var file = db.Files.Find(vm.FileID);
				SetFileFromVM(file, vm);
                db.Entry(caveFile).State = System.Data.Entity.EntityState.Modified;
				if(vm.Data != null) db.Entry(file).State = System.Data.Entity.EntityState.Modified;

				//caveFile.Cave = db.Caves.Find(vm.CaveID);
				//caveFile.CaveID = vm.CaveID;

				caveFile.Description = vm.Description;

				caveFile.FileType = db.FileTypes.Find(vm.FileTypeID);
				caveFile.FileTypeId = vm.FileTypeID;

                db.SaveChanges();
				return RedirectToAction("edit", "Caves", new { id = vm.CaveID }).AddFragment("CaveFilesSection");
            }
			vm.FileTypeSelectList = new SelectList(db.FileTypes, "FileTypeID", "Description", vm.FileTypeID);
            return View(vm);
        }

        // GET: CaveFiles/Delete/5
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			MetaFile caveFile = db.MetaFiles.Find(id);
            if (caveFile == null)
            {
                return HttpNotFound();
            }
            return View(caveFile);
        }

        // POST: CaveFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult DeleteConfirmed(int id)
        {
			MetaFile caveFile = db.MetaFiles.Find(id);
			db.MetaFiles.Remove(caveFile);
            db.SaveChanges();
			return RedirectToAction("edit", "Caves", new { id = caveFile.FileId }).AddFragment("CaveFilesSection");
        }


		public ActionResult ListCaveFiles(TableRequestModel request, CaveFilesModel model)
		{
			var caveFiles = db.Caves.Find(model.CaveID).MetaFiles;// MetaFiles.Where(p => p.CaveID == model.CaveID);
			return TableResult.From(caveFiles).Build<CaveFileTable>(request,1); //TODO - SOrt out this total rows thing.. that is currently set to 1
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
