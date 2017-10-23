using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;

namespace MaridoDeAluguelTests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TesteRetornoDePaginaIndex()
        {
            var controller = new HomeController();
            var pagina = controller.Index();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDePaginaAbout()
        {
            var controller = new HomeController();
            var pagina = controller.About();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDePaginaContact()
        {
            var controller = new HomeController();
            var pagina = controller.Contact();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }
    }
}
