using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Nhom03.Models.Taikhoan> Taikhoans { get; set; } = default!;

        public DbSet<Nhom03.Models.Giohang> Giohangs { get; set; }

        public DbSet<Nhom03.Models.Hoadon> Hoadons { get; set; }

        public DbSet<Nhom03.Models.Sanpham> Sanphams { get; set; }

        public DbSet<Nhom03.Models.Loaisanpham> Loaisanphams { get; set; }

        public DbSet<Nhom03.Models.Chitiethoadon> Chitiethoadons { get; set; }
    }
}
