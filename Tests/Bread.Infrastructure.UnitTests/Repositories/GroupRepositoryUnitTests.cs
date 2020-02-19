using Bread.Domain.Entities;
using Bread.Domain.Exceptions;
using Bread.Infrastructure.Data.Repositories;
using Xunit;

namespace Bread.Infrastructure.UnitTests.Repositories
{
    public class GroupRepositoryUnitTests
    {
        [Fact]
        public async void CreateGroup_Pass_When_ValidInput()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                string issuerId = "277AAEEC-AC90-4B0E-B1D3-C318AEF1A95C";
                applicationDbContext.Add(new ApplicationUser { Id = issuerId, UserName = "User" });

                // Act
                var sut = new GroupRepository(applicationDbContext);
                var group = await sut.CreateGroup(issuerId, new Domain.Dto.GroupInfo {
                    Name = "Name for Group",
                    MissionStatement = "Descriptio for Group"
                });

                // Assert
                Assert.NotNull(group);
            }
        }

        [Fact]
        public async void CreateGroup_ThrowBreadException_When_InvalidIssuer()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                string fakeIssuerId = "277AAEEC-AC90-4B0E-B1D3-C318AEF1A95C";
                // No user created for fakeIssuerId

                // Act
                await Assert.ThrowsAsync<BreadException>(async () => {
                    var sut = new GroupRepository(applicationDbContext);
                    var group = await sut.CreateGroup(fakeIssuerId, new Domain.Dto.GroupInfo {
                        Name = "Name for Group",
                        MissionStatement = "MissionStatement for Group"
                    });
                    // Assert
                    Assert.True(false, "sut.CreateGroup failed to raise exception as expected");
                });
            }
        }
    }

}
