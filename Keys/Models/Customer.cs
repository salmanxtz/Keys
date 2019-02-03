using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Keys.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string Address { get; set; }
		public virtual ICollection<ProductSold> ProductsSold { get; set; }
	}
}