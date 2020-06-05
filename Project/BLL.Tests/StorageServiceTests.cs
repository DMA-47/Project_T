using Catalog.BLL.Services.Impl;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class StorageServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new StorageService(nullUnitOfWork));
        }

        [Fact]
        public void GetStorages_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IStorageService storageService = new StorageService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => storageService.GetStorage(0));
        }

        [Fact]
        public void GetStorage_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new StorageManager(1, "test", 1);
            SecurityContext.SetUser(user);
            var storageService = GetStorageService();

            // Act
            var actualStorageDto = storageService.GetStorage(0).First();

            // Assert
            Assert.True(
                actualStorageDto.Id == 1
                && actualStorageDto.Name == "testN"
                && actualStorageDto.Description == "testD"
                );
        }

        IStorageService GetStorageService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedStorage = new Storage() { Id = 1, Name = "testN", Description = "testD"};
            var mockDbSet = new Mock<IStorageRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<Storage, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<Storage>() { expectedStorage }
                    );
            mockContext
                .Setup(context =>
                    context.Storages)
                .Returns(mockDbSet.Object);

            IStorageService streetService = new StorageService(mockContext.Object);

            return streetService;
        }
    }
}