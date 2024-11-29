namespace Chuade3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class QLBHDatacontext : DbContext
    {
        public QLBHDatacontext()
            : base("name=QLBHDatacontext")
        {
        }
        // tập các thực thể
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Xoá quy ước đặt tên bảng số nhiều
         //   modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            // Cấu hình cho thuộc tính đơn giá     
            modelBuilder.Entity<HoaDon>()
               .Property(p => p.Dongia)
               .HasPrecision(10, 2);          
            
        }
    }
}