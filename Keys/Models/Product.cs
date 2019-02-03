using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Keys.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public virtual ICollection<ProductSold> ProductsSold { get; set; }
	}
}