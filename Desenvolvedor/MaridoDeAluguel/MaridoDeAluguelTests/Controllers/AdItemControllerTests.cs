using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;

namespace MaridoDeAluguelTests.Controllers
{
    [TestClass]
    public class AdItemControllerTests
    {
        [TestMethod]
        public void TesteRetornoDePaginaIndex()
        {
            var controller = new AdItemController();
            var pagina = controller.Index("chave", 1, 1, "Date");
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteListagemDaPaginaCreate()
        {
            var controller = new AdItemController();
            var pagina = controller.Create();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteListagemDaPaginaDetails()
        {
            var controller = new AdItemController();
            var pagina = controller.Details(1);
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

    }
}
