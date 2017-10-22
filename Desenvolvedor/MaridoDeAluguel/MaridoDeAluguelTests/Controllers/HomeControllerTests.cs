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
    }
}
