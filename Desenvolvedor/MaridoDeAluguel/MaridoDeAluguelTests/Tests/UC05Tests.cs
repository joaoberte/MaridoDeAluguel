using MaridoDeAluguel.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    class UC05Tests
    {
        [TestMethod]
        public void TesteCriacaoCategoria()
        {
            var controller = new AdItemController();
            var verificador = controller.Create();
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDePaginaIndex()
        {
            var controller = new CategoriesController();
            var pagina = controller.Index();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDeCriacaoDecategoria()
        {
            var controller = new CategoriesController();
            var pagina = controller.Create();
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
        }
    }
}
