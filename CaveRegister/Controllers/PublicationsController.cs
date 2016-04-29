using System.Linq;
using System.Net;
using System.Web.Mvc;
using CaveRegister.Models;
using MvcTables;
using CaveRegister.MVCTableModels;
using CaveRegister.Attributes;
using CaveRegister.Model;

namespace CaveRegister.Controllers
{
	[Authorize]
    public class PublicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Publications
		/// <summary>
		/// Get All Publications fot the current Publication Entity
		/// </summary>
		/// <param name="id">PublicationEntityID</param>
		/// <returns></returns>
		[Roles(Role.Admin,Role.Contributor,Role.Observer)]
        public ActionResult Index(int id)
        {
			var vm = new PublicationsViewModel();
			vm.PublicationEntityID = id;
           // var publications = db.Publications.Include(p => p.PublicationEntity);
            return View(vm);
        }

        // GET: Publications/Details/5
		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // GET: Publications/Create
		/// <summary>
		/// Creates a publication for the specified Publication Entity
		/// </summary>
		/// <param name="id">PublicationEntityID</param>
		/// <returns></returns>
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Create(int id)
        {
			var newPublication = new Publication();
			newPublication.PublicationEntityId = id;
            return View(newPublication);
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Create([Bind(Include = "PublicationID,Name,PublicationDate,PublicationEntityID,FileLocation")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publication);
        }

        // GET: Publications/Edit/5
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin, Role.Contributor)]
        public ActionResult Edit([Bind(Include = "PublicationID,Name,PublicationDate,PublicationEntityID,FileLocation")] Publication publication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publication).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publication);
        }

        // GET: Publications/Delete/5
		[Roles(Role.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publication publication = db.Publications.Find(id);
            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Roles(Role.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            Publication publication = db.Publications.Find(id);
            db.Publications.Remove(publication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		[Roles(Role.Admin, Role.Contributor, Role.Observer)]
		public ActionResult ListPublications(TableRequestModel request, PublicationsViewModel model)
		{

			var publications = db.Publications.Where(p => p.PublicationEntityId == model.PublicationEntityID);
			return TableResult.From(publications).Build<PublicationTable>(request);
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
