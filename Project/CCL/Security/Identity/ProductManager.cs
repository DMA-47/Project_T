using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class ProductManager
        : User
    {
		public ProductManager() : base(0, "", nameof(ProductManager))
        {

        }

		public ProductManager(int userId, string name, int osbbId)
            : base(userId, name, nameof(ProductManager))
        {
        }
    }
}