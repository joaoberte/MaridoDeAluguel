using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC09UC10Tests
    {
        [TestMethod]
        public void TesteRetornoDePaginaDetails()
        {
            var controller = new AdItemController();
            var verificador = controller.Details(1);
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }

        [TestMethod]
        public void TesteRetornoDeEdicao()
        {
            var controller = new AdItemController();
            var verificador = controller.Edit(1);
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }
    }
}
