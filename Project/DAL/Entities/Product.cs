using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual void metod1() {}
    }
}
