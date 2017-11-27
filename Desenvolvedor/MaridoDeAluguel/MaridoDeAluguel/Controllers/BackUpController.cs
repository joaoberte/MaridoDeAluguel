using MaridoDeAluguel.Models;
using System;
using System.Web.Mvc;

namespace MaridoDeAluguel.Controllers
{
    public class BackUpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackUpController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: BackUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Backup()
        {
            string caminhoApp = AppDomain.CurrentDomain.BaseDirectory;
            string sourceFile = caminhoApp + "App_Data\\dadosRapidos-001.mdf";
            string destFile = caminhoApp + "App_Data\\dadosRapidos-001-Backup.mdf";

            System.IO.File.Copy(sourceFile, destFile, true);
        }
    }
}