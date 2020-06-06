using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
	class AddStorage : Storage
	{
		public int AddId { get; set; }
		public override void ShowAddress()
		{
			Console.WriteLine("Additional storage, id main storage:", AddId);
		}
	}
}
