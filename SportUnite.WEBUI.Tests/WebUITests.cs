using Microsoft.AspNetCore.Mvc;
using Moq;
using SportUnite.WEBUI.Controllers;
using SportUnite.WEBUI.Models;
using SportUnite.WEBUI.Models.ViewModels;
using System.Threading.Tasks;
using SportUnite.DAL;
using Xunit;

namespace SportUnite.WEBUI.Tests
{
    public class WebUITests
    {
        [Fact]
        public void SuccessfulLoginWithValidCredentails()
        {
            //Arrange
            LoginModel loginModel = new LoginModel();

            Mock<IAuthentication> authMock = new Mock<IAuthentication>();
            authMock.Setup(m => m.LoginAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));
   
            var controller = new AccountController(authMock.Object);

            //Act
            var result = controller.Login(loginModel).Result;
            //var viewResult = (ViewResult)controller.Login(loginModel).Result;

            //Assert
            Assert.True(result is RedirectResult);
            //Assert.Equal("About", viewResult.ViewName);
        }

        [Fact]
        public void UnsuccessfulLoginWithInvalidCredentails()
        {
            //Arrange
            LoginModel loginModel = new LoginModel();

            Mock<IAuthentication> authMock = new Mock<IAuthentication>();
            authMock.Setup(m => m.LoginAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(false));

            var controller = new AccountController(authMock.Object);

            //Act
            var result = controller.Login(loginModel).Result;

            //Assert
            Assert.True(result is ViewResult);
        }

        [Fact]
        public void SuccessfulLogoutWhenLoggedInWithValidCredentials()
        {
            //Arrange
            LoginModel loginModel = new LoginModel();

            Mock<IAuthentication> authMock = new Mock<IAuthentication>();
            authMock.Setup(m => m.LoginAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

            var controller = new AccountController(authMock.Object);

            //Act
            var result = controller.Logout().Result; //De result van de logout

            //Assert
            Assert.True(result is RedirectResult);
        }
    }
}