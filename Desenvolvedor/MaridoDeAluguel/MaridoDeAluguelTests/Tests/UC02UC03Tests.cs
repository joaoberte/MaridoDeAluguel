using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;
using MaridoDeAluguel.Models;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC02UC03Tests : Controller
    {
        [TestMethod]
        public void TesteDeRegistroUsuario()
        {
            var controller = new AccountController();
            var verificador = controller.Register();

            Assert.IsInstanceOfType(verificador, typeof(ViewResult));
        }
    }
}
