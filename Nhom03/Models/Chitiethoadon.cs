

namespace Eshop.Models
{
    public class Chitiethoadon
    {
        public int Id { get; set; }
        public int HoadonId { get; set; }
        public int SanphamId { get; set; }
        public int Soluong { get; set; } = 1;
        public int Dongia { get; set; } = 0;
    }
}
