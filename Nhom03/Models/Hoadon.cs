
namespace Nhom03.Models
{
    public class Hoadon
    {
        public int Id { get; set; }
        public string Mahoadon { get; set; }
        public int TaikhoanId { get; set; }
        public DateTime Ngaylap { get; set; } = DateTime.Now;
        public string Diachinhan { get; set; }  
        public string Sdtnhan { get; set; }  
        public int Tongcong { get; set; } = 0;   
        public bool Trangthai { get; set; } = true;

    }
}
