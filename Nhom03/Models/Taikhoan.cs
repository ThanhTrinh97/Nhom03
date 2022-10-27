

namespace Nhom03.Models
{
    public class Taikhoan
    {
        public int Id { get; set; }
        public string Dangnhap { get; set; }
        public string Matkhau { get; set; } 
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public string Hoten { get; set; }
        public bool Quanly { get; set; } = true;
        public string Hinhanh { get; set; }
        public bool Trangthai { get; set; } = true;


    }
}
