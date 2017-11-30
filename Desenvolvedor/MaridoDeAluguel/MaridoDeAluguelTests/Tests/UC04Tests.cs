using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaridoDeAluguel.Controllers;
using MaridoDeAluguel.ViewModel;
using MaridoDeAluguel.Models;

namespace MaridoDeAluguelTests.Tests
{
    [TestClass]
    public class UC04Tests : Controller
    {
        [TestMethod]
        public void TesteDeLogin()
        {
            var controller = new AccountController();
            LoginViewModel loginModel = new LoginViewModel();
            loginModel.Email = "joaoberte@pucrs.br";
            loginModel.Password = "123456";
            loginModel.RememberMe = false;

            Assert.AreEqual("joaoberte@pucrs.br", User.Identity.Name);
        }

    }
}
