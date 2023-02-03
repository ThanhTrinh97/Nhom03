using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Models;
using Microsoft.EntityFrameworkCore;
using Nhom03.Models;

namespace Nhom03.Data
{
    public class Nhom03Context : DbContext
    {
        public Nhom03Context (DbContextOptions<Nhom03Context> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}