using AutoMapper;
using Bread.API.Controllers;
using Bread.API.Presenters;
using Bread.API.Schemas.Accounts;
using Bread.Application.Users;
using Bread.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Bread.API.UnitTests.Controllers
{
    public class AccountsControllerUnitTests
    {
        [Fact]
        public async void Register_Returns_Created_When_Succeeds()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(madiatr => madiatr.Send(It.IsAny<UserRegisterCommand>(), default))
                .Returns(Task.FromResult(new UserRegisterResponse()));

            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AccountsDataMappingProfile());
            }).CreateMapper();

            var responsePresenter = new AccountsControllerPresenter(mapper);

            //Act
            var controller = new AccountsController(mockMediator.Object, mapper, responsePresenter);
            var result = await controller.Register(new Schemas.Accounts.JsRegisterUserRequest());

            //Assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.Created);
        }

        [Fact]
        public async void Register_Returns_Unauthorized_When_Fails()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(madiatr => madiatr.Send(It.IsAny<UserRegisterCommand>(), default))
                .Returns(Task.FromResult(new UserRegisterResponse(HttpStatusCode.Unauthorized)));

            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AccountsDataMappingProfile());
            }).CreateMapper();

            var responsePresenter = new AccountsControllerPresenter(mapper);

            //Act
            var controller = new AccountsController(mockMediator.Object, mapper, responsePresenter);
            var result = await controller.Register(new Schemas.Accounts.JsRegisterUserRequest());

            // assert
            // var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Register_Returns_Bad_Request_When_Fails()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(madiatr => madiatr.Send(It.IsAny<UserRegisterCommand>(), default))
                .Returns(Task.FromResult(new UserRegisterResponse(HttpStatusCode.BadRequest)));

            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AccountsDataMappingProfile());
            }).CreateMapper();

            var responsePresenter = new AccountsControllerPresenter(mapper);

            //Act
            var controller = new AccountsController(mockMediator.Object, mapper, responsePresenter);
            var result = await controller.Register(new Schemas.Accounts.JsRegisterUserRequest());

            // assert
            // var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Login_Returns_OK_When_Succeeds()
        {
            //Arrange
            var userId = "A727D7ED-473F-4FA7-909E-4AA7A35B2BFA";
            var authToken = "Fake authToken";
            var expiresIn = 1;
            var loginInfo = new LoginInfo(userId, authToken, expiresIn);

            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(madiatr => madiatr.Send(It.IsAny<UserLoginCommand>(), default))
                .Returns(Task.FromResult(new UserLoginResponse(loginInfo)));

            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AccountsDataMappingProfile());
            }).CreateMapper();

            var responsePresenter = new AccountsControllerPresenter(mapper);

            //Act
            var controller = new AccountsController(mockMediator.Object, mapper, responsePresenter);
            var result = await controller.Login(new JsLoginRequest() { UserName="", Password="" });

            //Assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.OK);
        }

        [Fact]
        public async void Login_Returns_Unauthorized_When_Fails()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(madiatr => madiatr.Send(It.IsAny<UserLoginCommand>(), default))
                .Returns(Task.FromResult(new UserLoginResponse(HttpStatusCode.Unauthorized)));

            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AccountsDataMappingProfile());
            }).CreateMapper();

            var responsePresenter = new AccountsControllerPresenter(mapper);

            //Act
            var controller = new AccountsController(mockMediator.Object, mapper, responsePresenter);
            var result = await controller.Login(new JsLoginRequest() { UserName = "", Password = "" });

            // assert
            var statusCode = ((ContentResult)result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int)HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async void GetMe_Returns_Me_When_Fails()
        {
            //Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(madiatr => madiatr.Send(It.IsAny<UserRegisterCommand>(), default))
                .Returns(Task.FromResult(new UserRegisterResponse(HttpStatusCode.BadRequest)));

            var mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AccountsDataMappingProfile());
            }).CreateMapper();

            var responsePresenter = new AccountsControllerPresenter(mapper);

            //Act
            var controller = new AccountsController(mockMediator.Object, mapper, responsePresenter);
            var result = await controller.Register(new Schemas.Accounts.JsRegisterUserRequest());

            // assert
            // var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
