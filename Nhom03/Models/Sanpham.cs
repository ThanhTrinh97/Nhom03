using System;
namespace Nhom03.Models
{
    public class Sanpham
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Tensanpham { get; set; }
        public string Mota { get; set; }
        public int Dongia { get; set; } = 0;
        public int Tonkho { get; set; } = 0;
        public int LoaisanphamId { get; set; }
        public string Hinhanh { get; set; }
        public bool Trangthai { get; set; } = true;

    }
}
