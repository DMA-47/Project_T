using Catalog.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.BLL.DTO;
using Catalog.DAL.Repositories.Interfaces;
using AutoMapper;
using Catalog.DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;

namespace Catalog.BLL.Services.Impl
{
    public class StorageService
        : IStorageService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public StorageService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<StorageDTO> GetStorage(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(ProductManager)
                && userType != typeof(StorageManager))
            {
                throw new MethodAccessException();
            }

            var storageEntities =
                _database
                    .Storages
                    .Find(pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Storage, StorageDTO>()
                    ).CreateMapper();
            var storageDto =
                mapper
                    .Map<IEnumerable<Storage>, List<StorageDTO>>(
                        storageEntities);
            return storageDto;
        }

        public void AddStreet(StorageDTO storage)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(ProductManager)
                && userType != typeof(StorageManager))
            {
                throw new MethodAccessException();
            }
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            validate(storage);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StorageDTO, Storage>()).CreateMapper();
            var storageEntity = mapper.Map<StorageDTO, Storage>(storage);
            _database.Storages.Create(storageEntity);
        }

        private void validate(StorageDTO storage)
        {
            if (string.IsNullOrEmpty(storage.Name))
            {
                throw new ArgumentException("Name повинне містити значення!");
            }
        }
    }
}