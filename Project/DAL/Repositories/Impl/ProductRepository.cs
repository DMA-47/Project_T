using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Catalog.DAL.Repositories.Impl
{
    public class ProductRepository
        : BaseRepository<Product>, IProductRepository
    {

        internal ProductRepository(ProjectContext context)
            : base(context)
        {
        }
    }
}