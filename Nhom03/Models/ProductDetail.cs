
using Nhom03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }

        [DisplayName("Màu sắc")]
        public string Color { get; set; }

        [DisplayName("Màn hình")]
        public string Screen { get; set; }

        [DisplayName("Hệ điều hành")]
        public string Operatingsystem { get; set; }

        [DisplayName("Bộ nhớ trong")]
        public string Room { get; set; }

        [DisplayName("Máy ảnh")]
        public string Frontcamera { get; set; }

        public string Chip { get; set; }

        [DisplayName("Bộ nhớ ngoài")]
        public string Ram { get; set; }

        
        public string Internalmemory { get; set; }

        [DisplayName("Sim")]
        public string Sim { get; set; }

        [DisplayName("Pin")]
        public string Rechargeablebatteries { get; set; }


        // Navigation reference property cho khóa ngoại đến Account 
        [DisplayName("Sản phẩm")]
        public int  ProductId { get; set; }
        public Product Product { get; set; }



    }
}
