
namespace Nhom03.Models
{
    public class Loaisanpham
    {
        public int Id { get; set; }
        public string Tenloai { get; set; }
        public bool Trangthai { get; set; } = true;
        public List<Sanpham> Sanphams { get; set; }
    }
}
