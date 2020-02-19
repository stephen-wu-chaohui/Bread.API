using Bread.Domain.Entities;
using Bread.Domain.Exceptions;
using Bread.Infrastructure.Data.Repositories;
using System;
using Xunit;

namespace Bread.Infrastructure.UnitTests
{
    public class AlbumRepositoryUnitTests
    {
        [Fact]
        public async void CreateAlbum_Pass_When_ValidInput()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                int groupId = 1;
                applicationDbContext.Add(new Group { Id = groupId, Name = "DemoGroup" });

                // Act
                var sut = new AlbumRepository(applicationDbContext);
                var album = await sut.CreateAlbum(groupId, new Domain.Dto.AlbumInfo {
                    Name = "Title for album",
                    Description = "Descriptio for album"
                });

                // Assert
                Assert.NotNull(album);
                Assert.NotEqual(0, album.Id);
            }
        }

        [Fact]
        public async void CreateAlbum_ThrowBreadException_When_InvalidGroupId()
        {
            using (var applicationDbContext = TestTools.CreateApplicationDbContext()) {
                // Arrange
                int fakeGroupId = 1;
                // no group created for fakeGroupId

                // Act
                var sut = new AlbumRepository(applicationDbContext);
                await Assert.ThrowsAsync<BreadException>(async () => {
                    var album = await sut.CreateAlbum(fakeGroupId, new Domain.Dto.AlbumInfo {
                        Name = "Name of album",
                        Description = "Descriptio for the album"
                    });

                    // Assert
                    Assert.True(false, "sut.CreateAlbum failed to raise exception as expected");
                });
            }
        }
    }

}
