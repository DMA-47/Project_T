using Catalog.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.EF
{
    public class ProjectContext
        : DbContext
    {
        public DbSet<Product> Osbbs { get; set; }
        public DbSet<Storage> Streets { get; set; }

        public ProjectContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}