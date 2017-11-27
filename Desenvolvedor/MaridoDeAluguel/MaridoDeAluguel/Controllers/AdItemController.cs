using MaridoDeAluguel.Models;
using MaridoDeAluguel.ViewModel;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace MaridoDeAluguel.Controllers
{
    public class AdItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdItemController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult Index(string searchString, int? page, int? idCategorie, string sortOrder)
        {
            var adItens = _context.AdItens.Where(a => (a.PostedAt.Value.Year != 1 && a.ClosedAt.Year == 1)).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Filter = searchString;
                adItens = _context.AdItens.Where(a => a.Title.Contains(searchString)).ToList();
            }
            if (idCategorie != null)
            {
                adItens = adItens.Where(p => p.Category.Id == idCategorie).ToList();
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "Date":
                    adItens = adItens.OrderBy(s => s.PostedAt).ToList();
                    break;
                case "date_desc":
                    adItens = adItens.OrderByDescending(s => s.PostedAt).ToList();
                    break;
                default:
                    adItens = adItens.OrderBy(s => s.Title).ToList();
                    break;
            }

            return View(adItens.ToPagedList(pageNumber, pageSize));
        }

        // GET: AdItem
        [Authorize(Roles = "Contratante")]
        public ActionResult Create()
        {
            var viewModel = new AdItemFormViewModel
            {
                States = _context.States.ToList(),
                Categories = _context.Categories.Where(c => c.ParentCategory != null).ToList()
            };

            return View(viewModel);
        }


        [Authorize(Roles = "Contratante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdItemFormViewModel viewModel)
        {
            Console.WriteLine(viewModel.Category);
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.States = _context.States.ToList();
                    viewModel.Categories = _context.Categories.ToList();
                    return View("Create", viewModel);
                }
                var adItem = new AdItem
                {
                    OwnerId = User.Identity.GetUserId(),
                    CategoryId = viewModel.Category,
                    Title = viewModel.Title,
                    CityId = viewModel.City,
                    Description = viewModel.Description,
                    flagType = viewModel.flagType,
                    StateId = viewModel.State,
                    PostedAt = DateTime.Now
                };
                var file = viewModel.ImageUpload[0];
                if (!(file == null || file.ContentLength == 0))
                {

                    var imagem = new Images
                    {
                        FileName = System.IO.Path.GetFileName(file.FileName),
                        FileType = FileType.ProductImage,
                        ContentType = file.ContentType
                    };

                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        imagem.Content = reader.ReadBytes(file.ContentLength);
                    }
                    adItem.Images = new List<Images> { imagem };
                }

                _context.AdItens.Add(adItem);
                _context.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            return RedirectToAction("MyAdItens", "AdItem");

        }

        [HttpPost]
        public ActionResult GetCityByStateId(int stateid)
        {
            List<City> objcity = new List<City>();
            objcity = _context.Cities.Where(m => m.State.Id == stateid).ToList();
            SelectList obgcity = new SelectList(objcity, "Id", "Name", 0);
            return Json(obgcity);
        }

        public ActionResult Details(int id)
        {
            AdItem adItem = _context.AdItens.Where(a => a.Id == id).FirstOrDefault();
            return View(adItem);
        }

        [Authorize(Roles = "FazTudo")]
        public ActionResult Buy(int id)
        {
            AdItem adItem = _context.AdItens.Where(a => a.Id == id).FirstOrDefault();
            return View(adItem);
        }

        [Authorize(Roles = "FazTudo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(AdItem adItem)
        {
            string Userid = User.Identity.GetUserId();
            ApplicationUser Buyer = _context.Users.Single(u => u.Id == Userid);

            AdItem adItemMod = _context.AdItens.Single(a => a.Id == adItem.Id);

            adItemMod.Buyer = Buyer;
            adItemMod.BuyerId = Buyer.Id;

            _context.Entry(adItemMod).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Contratante")]
        public ActionResult SellAdItens()
        {
            string UserId = User.Identity.GetUserId();
            List<AdItem> adItens = _context.AdItens.Where(a => a.Owner.Id == UserId && a.ClosedAt.Year == 1 && a.BuyerId != null).ToList();

            return View(adItens);
        }

        [Authorize(Roles = "Contratante")]
        public ActionResult Sell(int id)
        {
            AdItem adItem = _context.AdItens.Single(a => a.Id == id);

            return View(adItem);
        }

        [Authorize(Roles = "Contratante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sell(AdItem adItem)
        {
            AdItem adItemMod = _context.AdItens.Single(a => a.Id == adItem.Id);

            adItemMod.ClosedAt = DateTime.Now;

            _context.Entry(adItemMod).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Contratante")]
        public ActionResult CancelSell(int id)
        {
            AdItem adItem = _context.AdItens.Single(a => a.Id == id);

            adItem.Buyer = null;
            adItem.BuyerId = null;

            _context.Entry(adItem).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Contratante")]
        public ActionResult MyAdItens(string searchString, int? page, string sortOrder)
        {
            string UserId = User.Identity.GetUserId();
            var adItens = _context.AdItens.Where(a => a.Owner.Id == UserId && a.PostedAt != null).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Filter = searchString;
                adItens = _context.AdItens.Where(a => a.Title.Contains(searchString)).ToList();
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "Date":
                    adItens = adItens.OrderBy(s => s.PostedAt).ToList();
                    break;
                case "date_desc":
                    adItens = adItens.OrderByDescending(s => s.PostedAt).ToList();
                    break;
                default:
                    adItens = adItens.OrderBy(s => s.Title).ToList();
                    break;
            }
            return View(adItens.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult VerifyAdItens()
        {
            string UserId = User.Identity.GetUserId();
            List<AdItem> adItens = _context.AdItens.Where(a => a.PostedAt.Value.Year == 1).ToList();

            return View(adItens);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AcceptAdItem(int id)
        {
            AdItem adItem = _context.AdItens.Single(a => a.Id == id);

            adItem.PostedAt = DateTime.Now;

            _context.Entry(adItem).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("VerifyAdItens");
        }



        [Authorize(Roles = "Contratante")]
        public ActionResult Edit(int id)
        {
            AdItem adItem = _context.AdItens.Where(a => a.Id == id).FirstOrDefault();

            var viewModel = new AdItemFormViewModel
            {
                IdAdItem = adItem.Id,
                Title = adItem.Title,
                Description = adItem.Description,
                flagType = adItem.flagType,
                State = adItem.StateId,
                City = adItem.CityId,
                Category = adItem.CategoryId,
                States = _context.States.ToList(),
                Cities = _context.Cities.Where(m => m.State.Id == adItem.StateId).ToList(),
                Categories = _context.Categories.Where(c => c.ParentCategory != null).ToList()
            };

            return View(viewModel);
        }


        [Authorize(Roles = "Contratante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdItemFormViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.States = _context.States.ToList();
                    viewModel.Categories = _context.Categories.ToList();
                    return View("Create", viewModel);
                }

                AdItem adItem = _context.AdItens.Single(a => a.Id == viewModel.IdAdItem);


                adItem.CategoryId = viewModel.Category;
                adItem.Title = viewModel.Title;
                adItem.CityId = viewModel.City;
                adItem.Description = viewModel.Description;
                adItem.flagType = viewModel.flagType;
                adItem.StateId = viewModel.State;

                var file = viewModel.ImageUpload[0];
                if (!(file == null || file.ContentLength == 0))
                {

                    var imagem = new Images
                    {
                        FileName = System.IO.Path.GetFileName(file.FileName),
                        FileType = FileType.ProductImage,
                        ContentType = file.ContentType
                    };

                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        imagem.Content = reader.ReadBytes(file.ContentLength);
                    }
                    adItem.Images = new List<Images> { imagem };
                }

                _context.Entry(adItem).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Não Foi Possível atualizar as informações do anuncio.");
            }


            return RedirectToAction("MyAdItens", "AdItem");

        }



        [Authorize(Roles = "Contratante, Admin")]
        public ActionResult RemoveAdItem(int id)
        {

            AdItem adItem = _context.AdItens.Single(a => a.Id == id);

            _context.AdItens.Remove(adItem);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            return View();
        }
    }
}