using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;
using MaridoDeAluguel.Models;
using System;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC07Tests
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
        public void TesteListagemDaPaginaCreate()
        {
            var controller = new AdItemController();
            var verificador = controller.Create();
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }
    }
}
