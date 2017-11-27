using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;
using MaridoDeAluguel.Models;
using System;

namespace MaridoDeAluguelTests.Context
{
    [TestClass]
    public class ContextoTests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [TestMethod]
        public void TesteCriacaoAdItem()
        {
            

            var adItem = new AdItem
            {
                OwnerId = "1",
                CategoryId = 1,
                Title = "Novo Anuncio",
                CityId = 1,
                Description = "Descrição Teste",
                flagType = true,
                StateId = 1,
                PostedAt = DateTime.Now
            };

            _context.AdItens.Add(adItem);
            var resultado = _context.SaveChanges();

            Assert.Equals("", typeof(ViewResult));
        }

        [TestMethod]
        public void TesteCriacaoCategoria()
        {
            var controller = new AdItemController();
            var pagina = controller.Create();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

    }
}
