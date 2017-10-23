using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;

namespace MaridoDeAluguelTests.Controllers
{
    [TestClass]
    public class CategoriesControllerTests
    {
        [TestMethod]
        public void TesteRetornoDePaginaIndex()
        {
            var controller = new CategoriesController();
            var pagina = controller.Index();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDePaginaCreate()
        {
            var controller = new CategoriesController();
            var pagina = controller.Create();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }
    }
}
