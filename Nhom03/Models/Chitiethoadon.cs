namespace Nhom03.Models
{
    public class Chitiethoadon
    {
        public int Id { get; set; }

        public int HoadonId { get; set; }
       
        public Hoadon Hoadon { get; set; }

        public int SanphamId { get; set; }

        
        public Sanpham Sanpham { get; set; }

       
        public int Soluong { get; set; } = 1;

        
        public int Dongia { get; set; } = 0;
    }
}
