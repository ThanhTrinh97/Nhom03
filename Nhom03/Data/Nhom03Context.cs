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

        public DbSet<Account> Accounts { get; set; } = default!;
		public DbSet<Cart> Carts { get; set; } = default!;
		public DbSet<Invoice> Invoices { get; set; } = default!;
		public DbSet<InvoiceDetail> InvoiceDetails { get; set; } = default!;
		public DbSet<Product> Products { get; set; } = default!;
		public DbSet<ProductType> ProductTypes { get; set; } = default!;
        public DbSet<ProductDetail> ProductDetails { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
    }
}