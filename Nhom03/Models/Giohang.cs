﻿

namespace Nhom03.Models
{
    public class Giohang
    {
        public int Id { get; set; }
        public int TaikhoanId { get; set; }
        public Taikhoan Taikhoan { get; set; }
        public int SanphamId { get; set; }
        public Sanpham Sanpham { get; set; }
        public int Soluong { get; set; } = 1;
    }
}
