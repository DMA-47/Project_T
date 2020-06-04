using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
	class Storage
	{
		public int Id { get; set; }
		public Product List_product { get; set; }
		public int Num_list { get; set; }
	}
}
