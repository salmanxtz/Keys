using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Keys.Models;

namespace Keys.DAL
{
	public class KeysContext: DbContext
	{
		public KeysContext() : base("KeysContext")
		{
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductSold> ProductsSolds { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}