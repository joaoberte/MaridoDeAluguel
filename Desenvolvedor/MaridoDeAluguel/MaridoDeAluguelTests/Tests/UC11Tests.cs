using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC11Tests
    {
        [TestMethod]
        public void TesteVerificarVenda()
        {
            var controller = new AdItemController();
            var verificador = controller.Sell(1);

            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }
    }
}
