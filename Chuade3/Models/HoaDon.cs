using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chuade3.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key,Column(Order =0)]
        [ForeignKey("KhachHang")]
        public int MaKH { get; set; }
        [Key,Column(Order =1)]
        [StringLength(50)]
        public string TenSP { get; set; }
        [Required(ErrorMessage ="Không để trống")]
        [DataType(DataType.Date,ErrorMessage ="Định dạng ngày/tháng/năm")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Ngaylap{ get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public decimal Dongia { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public int Soluong { get; set; }
        // Tính thành tiền
        public decimal ThanhTien => Soluong * Dongia;
        public KhachHang KhachHang { get; set; }
    }
}