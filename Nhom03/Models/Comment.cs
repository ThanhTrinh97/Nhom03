using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nhom03.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DisplayName("Mã nội dung")]
        public string MaND { get; set; }

        [DisplayName("Đánh giá")]
        public int Sosao { get; set; }

        [DisplayName("Bình luận")]
        public string Binhluan { get; set; }

        [DisplayName("Ngày bình luận")]
        [DataType(DataType.DateTime)]
        public DateTime Ngaylap { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        // Navigation reference property cho khóa ngoại đến ProductType
        [DisplayName("Sản phẩm")]
        public Product Product { get; set; }

        
    }
}
