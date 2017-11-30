using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC16Tests
    {
        [TestMethod]
        public void TesteRetornoDePaginaIndex()
        {
            var controller = new AdItemController();
            var verificador = controller.Index("chave", 1, 1, "Date");
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteListagemDaPaginaDetailsDeUmaOferta()
        {
            var controller = new AdItemController();
            var verificador = controller.Details(1);
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }

    }
}
