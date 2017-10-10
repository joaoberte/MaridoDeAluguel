using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaridoDeAluguel.Models;
using MaridoDeAluguel.ViewModel;

namespace MaridoDeAluguel.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            CategoryViewModel CategoryVM = new CategoryViewModel();
            CategoryVM.ParentCategories = new SelectList(db.Categories.Where(c => c.ParentCategory == null), "ID", "Name");
            return View(CategoryVM);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CategoryViewModel CategoryVM)
        {
            Category category = new Category();
            category.Name = CategoryVM.Name;
            if (CategoryVM.SelectedCategorie != null)
            {
                category.ParentCategory = db.Categories.Where(c => c.Id == CategoryVM.SelectedCategorie).FirstOrDefault();
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Include(c => c.SubCategories).Single(c => c.Id == id);
            

            if (category.SubCategories != null)
            {
                db.Categories.RemoveRange(category.SubCategories);
            }

            db.Categories.Remove(category);
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
