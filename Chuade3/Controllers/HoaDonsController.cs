using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chuade3.Models;

namespace Chuade3.Controllers
{
    public class HoaDonsController : Controller
    {
        private QLBHDatacontext db = new QLBHDatacontext();

        // GET: HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang);
            return View(hoaDons.ToList());
        }
        public ActionResult Timkiem()
        {           
            var dskh = db.KhachHangs.ToList();
            ViewBag.KhachHangs = dskh.Select(c => new SelectListItem
            {
                Value = c.MaKH.ToString(), 
                Text = c.Hoten  
            }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Timkiem(int MaKH)
        {            
            var dshd = db.HoaDons
            .Where(hd => hd.MaKH == MaKH)
            .Include(hd => hd.KhachHang)
            .ToList();
            // tải lại toàn bộ ds khách hàng lên trên DropDownList            
            var dskh = db.KhachHangs.ToList();
            ViewBag.KhachHangs = dskh.Select(c => new SelectListItem
            {
                Value = c.MaKH.ToString(),
                Text = c.Hoten
            }).ToList();
            // Trả lại view với dữ liệu hóa đơn đã lọc , truyền giá trị từ COntroller->View = ViewBag
            ViewBag.dshd = dshd;
            return View();
         }
        // Tổng tiền Max
        public ActionResult TongtienMax()
        {
            var dshoadon = db.HoaDons.Include("KhachHang").GroupBy(x => new { x.KhachHang.MaKH, x.KhachHang.Hoten })
                          .Select(g => new
                          {
                              MaKH = g.Key.MaKH,
                              Hoten = g.Key.Hoten,
                              Tongtien = g.Sum(x => x.Soluong * x.Dongia)
                          }).OrderByDescending(g => g.Tongtien);
            ViewBag.MaKH = dshoadon.First().MaKH;
            ViewBag.Hoten = dshoadon.First().Hoten;
            ViewBag.Tongtien = dshoadon.First().Tongtien;
            return View();                 
        }
       public ActionResult Details(int? MaKH, string TenSP)
        {

            if (TenSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(MaKH,TenSP);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {           
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "Hoten");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenSP,Ngaylap,Dongia,Soluong")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)  
                if(KTtrungkhoa(hoaDon.MaKH,hoaDon.TenSP)==true) // chưa có trong bảng Hoá đơn
                {
                    db.HoaDons.Add(hoaDon);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else ViewBag.Thongbao = "Trùng khoá";
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "Hoten", hoaDon.MaKH);
            return View(hoaDon);
        }
        // Kiểm tra trùng khoá trong bảng hoá đơn
        public bool KTtrungkhoa(int MaKH, string TenSP)
        {
            var hd = db.HoaDons.Find(MaKH, TenSP);
            // kiêm tra kq tìm kiếm
            if (hd == null) return true; // true là không trùng khoá, chưa có
            return false; // đã có
        }
      
        // GET: HoaDons/Edit/5
        public ActionResult Edit(int? MaKH, string TenSP)
        {
            if (TenSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(MaKH, TenSP);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "Hoten", hoaDon.MaKH);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenSP,Ngaylap,Dongia,Soluong")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "Hoten", hoaDon.MaKH);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(int? MaKH, string TenSP)
        {
            if (TenSP== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(MaKH,TenSP);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int MaKH, string TenSP)
        {
            HoaDon hoaDon = db.HoaDons.Find(MaKH,TenSP);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
