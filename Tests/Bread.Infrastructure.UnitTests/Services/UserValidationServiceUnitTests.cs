using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Xunit;
using Moq;
using Bread.Domain.Entities;
using Bread.Infrastructure.Services;

namespace Bread.Infrastructure.UnitTests.Services
{
    public class UserValidationServiceUnitTests
    {
        [Fact]
        public async void IsEmailUnique_Returns_True_When_UserIsNull()
        {
            //Arrange
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
            userManagerMock.Setup(s => s.FindByEmailAsync("Null")).Returns(Task.FromResult((ApplicationUser)null));

            //Act
            var sut = new UserValidationService(userManagerMock.Object);

            //Assert
            Assert.True(await sut.IsEmailUnique("Null"));
        }

        [Fact]
        public async void IsEmailUnique_Returns_False_When_UserNotNull()
        {
            //Arrange
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
            userManagerMock.Setup(s => s.FindByEmailAsync("NotNull")).Returns(Task.FromResult(new ApplicationUser()));

            //Act
            var sut = new UserValidationService(userManagerMock.Object);

            //Assert
            Assert.False(await sut.IsEmailUnique("NotNull"));
        }
    }
}
