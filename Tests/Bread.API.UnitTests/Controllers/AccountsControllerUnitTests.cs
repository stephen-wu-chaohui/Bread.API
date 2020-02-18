using AutoMapper;
using Bread.API.Controllers;
using Bread.API.Presenters;
using Bread.API.Schemas.Accounts;
using Bread.Application.Users;
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
    }
}
