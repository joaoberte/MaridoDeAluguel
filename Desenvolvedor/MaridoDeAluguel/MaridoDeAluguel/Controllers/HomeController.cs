using MaridoDeAluguel.Models;
using System.Linq;
using System.Web.Mvc;

namespace MaridoDeAluguel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetPageCategories()
        {
            var categories = _context.Categories.ToList(); //Get your categs
            return PartialView(@"~/Views/Shared/listmenu.cshtml", categories);
        }
    }
}