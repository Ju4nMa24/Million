using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Million.Application.Database;
using Million.Application.Database.Commands.Address.CreateAddressCommand;
using Million.Application.Database.Commands.Owner.CreateOwnerCommand;
using Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;
using Moq;

namespace Million.Test.Test.Owner
{
    public class CreateOwnerCommandTests
    {
        public static Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
        {
            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            // Soporte para AddAsync
            mockSet.Setup(m => m.AddAsync(It.IsAny<T>(), It.IsAny<CancellationToken>()))
                   .Callback<T, CancellationToken>((entity, _) => data.Add(entity))
                   .Returns<T, CancellationToken>((entity, _) =>
                       ValueTask.FromResult<EntityEntry<T>>(null!));

            return mockSet;
        }
        [Fact]
        public async Task Execute_Should_Create_Owner_When_Valid_Model()
        {
            // Arrange
            var dbMock = new Mock<IDataBaseService>();
            var mapperMock = new Mock<IMapper>();
            var createAddressMock = new Mock<ICreateAddressCommand>();

            var fakeOwnersList = new List<OwnerEntity>();
            var ownersDbSetMock = CreateMockDbSet(fakeOwnersList);
            dbMock.Setup(x => x.Owners).Returns(ownersDbSetMock.Object);

            dbMock.Setup(x => x.Owners.AddAsync(It.IsAny<OwnerEntity>(), It.IsAny<CancellationToken>()))
                  .Callback<OwnerEntity, CancellationToken>((owner, _) => fakeOwnersList.Add(owner))
                  .Returns<OwnerEntity, CancellationToken>((owner, _) =>
                      ValueTask.FromResult<EntityEntry<OwnerEntity>>(null!));

            dbMock.Setup(x => x.SaveAsync()).ReturnsAsync(true);

            CreateAddressModel addressResult = new() { 
                IdAddress = Guid.NewGuid(),
                City = "New York",
                Country = "USA",
                State = "NY",
                Street = "123 Main St",
                ZipCode = "10001",
                CreationDate = DateTime.UtcNow,
                ModificationDate = DateTime.UtcNow
            };
            createAddressMock.Setup(x => x.Execute(It.IsAny<CreateAddressModel>()))
                             .ReturnsAsync(addressResult);

            mapperMock.Setup(x => x.Map<OwnerEntity>(It.IsAny<CreateOwnerModel>()))
                      .Returns((CreateOwnerModel model) =>
                      {
                          var addressEntity = new AddressEntity
                          {
                              City = model.Address.City,
                              Country = model.Address.Country,
                              State = model.Address.State,
                              Street = model.Address.Street,
                              ZipCode = model.Address.ZipCode
                          };

                          var ownerEntity = new OwnerEntity
                          {
                              Name = model.Name,
                              Birthday = model.Birthday,
                              Photo = model.Photo,
                              Address = addressEntity 
                          };

                          return ownerEntity;
                      });

            var createOwnerCommand = new CreateOwnerCommand(
                dbMock.Object, mapperMock.Object, createAddressMock.Object);


            var model = new CreateOwnerModel
            {
                Name = "John Doe",
                Birthday = new DateTime(1990, 1, 1),
                Address = new CreateAddressModel
                {
                    City = "New York",
                    Country = "USA",
                    State = "NY",
                    Street = "123 Main St",
                    ZipCode = "10001"
                },
                Contact = new CreateOwnerContactModel
                {
                    Email = "john@example.com",
                    Phone = "1234567890",
                    Type = "Personal"
                }
            };

            // Act
            var result = await createOwnerCommand.Execute(model);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("John Doe");
            result.IdOwner.Should().NotBe(Guid.Empty);
            fakeOwnersList.Should().HaveCount(1);
            dbMock.Verify(x => x.SaveAsync(), Times.Once);
        }
    }
}
