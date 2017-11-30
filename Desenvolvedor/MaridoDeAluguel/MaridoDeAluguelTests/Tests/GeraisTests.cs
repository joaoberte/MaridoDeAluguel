using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class GeraisTests
    {
        [TestMethod]
        public void TesteRetornoDePaginaIndex()
        {
            var controller = new HomeController();
            var verificador = controller.Index();
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDePaginaAbout()
        {
            var controller = new HomeController();
            var verificador = controller.About();
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDePaginaContact()
        {
            var controller = new HomeController();
            var verificador = controller.Contact();
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }
    }
}
