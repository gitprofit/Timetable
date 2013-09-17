using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace TimetableModel.Model.Northwind
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string Picture { get; set; }

		//[Association("Product", "CategoryID", "CategoryID")]
		//public ICollection<Product> Products { get; set; }
	}

	class CategoryMapping : EntityTypeConfiguration<Category>
	{
		public CategoryMapping()
			: base()
		{
			this.HasKey(t => t.CategoryID).Property(t => t.CategoryID).HasColumnName("CategoryID");

			this.Property(t => t.CategoryName).HasMaxLength(15).HasColumnName("CategoryName");
			this.Property(t => t.Description).HasColumnName("Description");
			this.Property(t => t.Picture).HasMaxLength(40).HasColumnName("Picture");

			//this.HasMany(t => t.Products).WithRequired().HasForeignKey(t => t.Category);
			//this.HasMany(t => t.Products).WithRequired().Map(t => t.MapKey("ProductID"));

			this.ToTable("categories");
		}
	}



	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		//[

		public string QuantityPerUnit { get; set; }

		public Supplier Supplier { get; set; }
		//[System.ComponentModel.DataAnnotations.Association("Category", "CategoryID", "CategoryID")]
		//[ForeignKey("CategoryID")]
		public Category Category { get; set; }
	}

	class ProductMapping : EntityTypeConfiguration<Product>
	{
		public ProductMapping()
			: base()
		{

			this.HasKey(t => t.ProductID).Property(t => t.ProductID).HasColumnName("ProductID");

			this.Property(t => t.ProductName).HasMaxLength(40).HasColumnName("ProductName");
			this.Property(t => t.QuantityPerUnit).HasColumnName("QuantityPerUnit");

			this.HasOptional(t => t.Supplier).WithMany().Map(t => t.MapKey("SupplierID"));
			this.HasOptional(t => t.Category).WithMany().Map(t => t.MapKey("CategoryID"));

			this.ToTable("products");
		}
	}


	public class Supplier
	{
		public int SupplierID { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }

		//public ICollection<Product> Products { get; set; }
	}

	class SupplierMapping : EntityTypeConfiguration<Supplier>
	{
		public SupplierMapping()
			: base()
		{
			this.HasKey(t => t.SupplierID).Property(t => t.SupplierID).HasColumnName("SupplierID");

			this.Property(t => t.CompanyName).HasColumnName("CompanyName");
			this.Property(t => t.ContactName).HasColumnName("ContactName");
			this.Property(t => t.ContactTitle).HasColumnName("ContactTitle");
			this.Property(t => t.Address).HasColumnName("Address");
			this.Property(t => t.City).HasColumnName("City");
			this.Property(t => t.Region).HasColumnName("Region");
			this.Property(t => t.PostalCode).HasColumnName("PostalCode");
			this.Property(t => t.Country).HasColumnName("Country");
			this.Property(t => t.Phone).HasColumnName("Phone");

			//this.HasMany<Product>(t => t.Products).WithOptional().HasForeignKey(t => t.Supplier);

			this.ToTable("suppliers");
		}
	}


	public class NorthwindContext : DbContext
	{
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		public NorthwindContext(string connStr)
			: base(connStr)
		{
			Database.SetInitializer<NorthwindContext>(null);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new SupplierMapping());
			modelBuilder.Configurations.Add(new ProductMapping());
			modelBuilder.Configurations.Add(new CategoryMapping());
		}
	}

}
