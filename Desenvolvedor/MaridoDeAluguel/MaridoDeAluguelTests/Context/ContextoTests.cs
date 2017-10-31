using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;

namespace MaridoDeAluguelTests.Context
{
    [TestClass]
    public class ContextoTests
    {
        [TestMethod]
        public void TesteCriacaoAdItem()
        {
            var controller = new AdItemController();
            var pagina = controller.Index("chave", 1, 1, "Date");
            Assert.IsInstanceOfType(pagina, typeof(ViewResult));
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
