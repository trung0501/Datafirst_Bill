using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chuade3.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        [Required(ErrorMessage ="Không để trống")]
        [StringLength(50,MinimumLength = 4,ErrorMessage ="tên từ 4-50")]
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        [StringLength(15)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"0\d{9,10}")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        [StringLength(50)]
        public string Diachi { get; set; }
        // Quan hệ với bảng hoá đơn
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}