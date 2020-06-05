using System;
using Xunit;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestStorageRepository
        : BaseRepository<Storage>
    {
        public TestStorageRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputStorageInstance_CalledAddMethodOfDBSetWithStorageInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<ProjectContext>()
                .Options;
            var mockContext = new Mock<ProjectContext>(opt);
            var mockDbSet = new Mock<DbSet<Storage>>();
            mockContext
                .Setup(context =>
                    context.Set<Storage>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestStorageRepository(mockContext.Object);

            Storage expectedStorage = new Mock<Storage>().Object;

            //Act
            repository.Create(expectedStorage);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStorage
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<ProjectContext>()
                .Options;
            var mockContext = new Mock<ProjectContext>(opt);
            var mockDbSet = new Mock<DbSet<Storage>>();
            mockContext
                .Setup(context =>
                    context.Set<Storage>(
                        ))
                .Returns(mockDbSet.Object);
      
            var repository = new TestStorageRepository(mockContext.Object);

            Storage expectedStorage = new Storage() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStorage.Id)).Returns(expectedStorage);

            //Act
            repository.Delete(expectedStorage.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStorage.Id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStorage
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<ProjectContext>()
                .Options;
            var mockContext = new Mock<ProjectContext>(opt);
            var mockDbSet = new Mock<DbSet<Storage>>();
            mockContext
                .Setup(context =>
                    context.Set<Storage>(
                        ))
                .Returns(mockDbSet.Object);

            Storage expectedStorage = new Storage() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStorage.Id))
                    .Returns(expectedStorage);
            var repository = new TestStorageRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStorage.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStorage.Id
                    ), Times.Once());
            Assert.Equal(expectedStorage, actualStreet);
        }


    }
}