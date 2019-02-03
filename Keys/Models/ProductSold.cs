using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Keys.Models
{
	public class ProductSold
	{
		public int ProductSoldId { get; set; }
		public int ProductId { get; set; }
		public int CustomerId { get; set; }
		public int StoreId { get; set; }
		public DateTime DateSold { get; set; }

		public virtual Product Product { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual Store Store { get; set; }

	}
}