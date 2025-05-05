using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Million.Application.Database;
using Million.Application.Database.Commands.Owner.DeleteOwnerCommand;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;
using Million.Test.Common;
using Moq;

namespace Million.Test.Test.Owner
{
    public class DeleteOwnerCommandTests
    {
        [Fact]
        public async Task DeleteOwnerCommand_Should_Delete_Owner_When_Found()
        {
            // Arrange
            var fakeOwnersList = new List<OwnerEntity>
            {
                new() {
                    IdOwner = Guid.NewGuid(),
                    Name = "John Doe",
                    Birthday = DateTime.UtcNow,
                    Photo = "photo.jpg",
                    Address = new AddressEntity
                    {
                        IdAddress = Guid.NewGuid(),
                        City = "New York",
                        Country = "USA",
                        State = "NY",
                        Street = "123 Main St",
                        ZipCode = "10001"
                    }
                }
            };

            var dbMock = new Mock<IDataBaseService>();

            // Create a mock DbSet with async support
            var mockSet = new Mock<DbSet<OwnerEntity>>();

            // Setup the IQueryable properties
            var queryable = fakeOwnersList.AsQueryable();
            mockSet.As<IQueryable<OwnerEntity>>().Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<OwnerEntity>(queryable.Provider));
            mockSet.As<IQueryable<OwnerEntity>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<OwnerEntity>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<OwnerEntity>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            // Setup async methods
            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
                .ReturnsAsync((object[] ids) => fakeOwnersList.FirstOrDefault(e => e.IdOwner == (Guid)ids[0]));

            mockSet.Setup(m => m.Remove(It.IsAny<OwnerEntity>()))
                .Callback<OwnerEntity>((entity) => fakeOwnersList.Remove(entity));

            dbMock.Setup(x => x.Owners).Returns(mockSet.Object);
            dbMock.Setup(x => x.SaveAsync()).Returns(Task.FromResult(true)); 

            var deleteOwnerCommand = new DeleteOwnerCommand(dbMock.Object);
            var model = new DeleteOwnerModel { IdOwner = fakeOwnersList[0].IdOwner };

            // Act
            var result = await deleteOwnerCommand.Execute(model);

            // Assert
            result.Should().BeTrue();
            fakeOwnersList.Should().BeEmpty();
            dbMock.Verify(x => x.SaveAsync(), Times.Once);
        }
    }





}