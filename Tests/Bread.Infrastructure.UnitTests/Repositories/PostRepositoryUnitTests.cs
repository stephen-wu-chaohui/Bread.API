using Xunit;
using Bread.Domain.Entities;
using Bread.Domain.Exceptions;
using Bread.Infrastructure.Data.Repositories;

namespace Bread.Infrastructure.UnitTests.Repositories
{
    public class PostRepositoryUnitTests
    {
        [Fact]
        public async void CreatePost_Pass_When_ValidInput()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                string issuerId = "277AAEEC-AC90-4B0E-B1D3-C318AEF1A95C";
                int groupId = 1;
                int albumId = 10;

                applicationDbContext.Add(new ApplicationUser { Id = issuerId, UserName = "User" });
                applicationDbContext.Add(new Group { Id = groupId, Name = "DemoGroup" });
                applicationDbContext.Add(new Album { Id = albumId, Name = "DemoAlbum" });

                // Act
                var sut = new PostRepository(applicationDbContext);
                var post = await sut.CreatePost(albumId, issuerId, new Domain.Dto.PostInfo {
                    Title = "Title for Post",
                    Description = "Descriptio for Post"
                });

                // Assert
                Assert.NotNull(post);
            }
        }

        [Fact]
        public async void CreatePost_ThrowBreadException_When_InvalidIssuer()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                string fakeIssuerId = "277AAEEC-AC90-4B0E-B1D3-C318AEF1A95C";
                int groupId = 1;
                int albumId = 10;

                applicationDbContext.Add(new Group { Id = groupId, Name = "DemoGroup" });
                applicationDbContext.Add(new Album { Id = albumId, Name = "DemoAlbum" });
                // But no user created for fakeIssuerId

                // Act
                await Assert.ThrowsAsync<BreadException>(async () => {
                    var sut = new PostRepository(applicationDbContext);
                    var post = await sut.CreatePost(albumId, fakeIssuerId, new Domain.Dto.PostInfo {
                        Title = "Title for Post",
                        Description = "Descriptio for Post"
                    });
                    // Assert
                    Assert.True(false, "sut.CreatePost failed to raise exception as expected");
                });
            }
        }

        [Fact]
        public async void CreatePost_ThrowBreadException_When_InvalidAlbum()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                string fakeIssuerId = "277AAEEC-AC90-4B0E-B1D3-C318AEF1A95C";
                int groupId = 1;
                int albumId = 10;

                applicationDbContext.Add(new Group { Id = groupId, Name = "DemoGroup" });
                applicationDbContext.Add(new Album { Id = albumId, Name = "DemoAlbum" });
                // But no user created for fakeIssuerId

                // Act
                var sut = new PostRepository(applicationDbContext);
                await Assert.ThrowsAsync<BreadException>(async () => {
                    var post = await sut.CreatePost(albumId, fakeIssuerId, new Domain.Dto.PostInfo {
                        Title = "Title for Post",
                        Description = "Descriptio for Post"
                    });

                    // Assert
                    Assert.True(false, "sut.CreatePost failed to raise exception as expected");
                });
            }
        }
    }
}
