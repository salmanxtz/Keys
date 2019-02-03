using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Keys.Models
{
	public class Store
	{
		public int StoreId { get; set; }
		public string StoreName { get; set; }
		public string StoreAddress { get; set; }
		public virtual ICollection<ProductSold> ProductsSold { get; set; }
	}
}