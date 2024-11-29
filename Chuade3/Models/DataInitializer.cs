using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chuade3.Models
{
    public class DataInitializer:DropCreateDatabaseAlways<QLBHDatacontext>
    {
        protected override void Seed(QLBHDatacontext context)
        {
            context.KhachHangs.Add(new KhachHang
            {
                MaKH = 1,
                Hoten = "Nguyễn Văn Tú",
                SDT = "0989789876",
                Diachi = "Hải Dương"
            });
            context.KhachHangs.Add(new KhachHang
            {
                MaKH = 2,
                Hoten = "Nguyễn Văn Thanh",
                SDT = "0989789876",
                Diachi = "Hà Nội"
            });
            context.KhachHangs.Add(new KhachHang
            {
                MaKH = 3,
                Hoten = "Trần Thị Thảo",
                SDT = "0989789876",
                Diachi = "Nam Định"
            });
            context.SaveChanges();
            context.HoaDons.Add(new HoaDon
            {
                MaKH=1,
                TenSP="Ti vi",
                Ngaylap= Convert.ToDateTime("12/11/2024"),
                Dongia=500000,
                Soluong=3

            });
            context.HoaDons.Add(new HoaDon
            {
                MaKH = 1,
                TenSP = "Tủ lạnh",
                Ngaylap = Convert.ToDateTime("12/11/2024"),
                Dongia = 8000000,
                Soluong = 2

            });
            context.HoaDons.Add(new HoaDon
            {
                MaKH = 1,
                TenSP = "Điều hoà",
                Ngaylap = Convert.ToDateTime("12/11/2024"),
                Dongia = 500000,
                Soluong = 3

            });
            context.HoaDons.Add(new HoaDon
            {
                MaKH = 2,
                TenSP = "Ti vi",
                Ngaylap = Convert.ToDateTime("12/11/2024"),
                Dongia = 500000,
                Soluong = 2
            });
            context.HoaDons.Add(new HoaDon
            {
                MaKH = 2,
                TenSP = "Máy giặt",
                Ngaylap = Convert.ToDateTime("12/11/2024"),
                Dongia = 500000,
                Soluong = 3
            });
            context.SaveChanges();
            base.Seed(context);
        }


    }
}