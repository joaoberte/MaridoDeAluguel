using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC17Tests
    {
        [TestMethod]
        public void TesteOfertaDeServico()
        {
            var controller = new AdItemController();
            var verificador = controller.Buy(1);
            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }
    }
}
