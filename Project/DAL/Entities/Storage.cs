using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
	public class Storage
	{
		public int Id { get; set; }
		public string address { get; set; }
		public Product List_product { get; set; }
		public int Num_list { get; set; }

		public void metod2() { }

		public void AllShow()
		{
			ShowId();
			ShowAddress();
		}
		public virtual void ShowId()
		{
			Console.WriteLine(Id);
		}
		public virtual void ShowAddress()
		{
			Console.WriteLine(address);
		}
		
	}
}
