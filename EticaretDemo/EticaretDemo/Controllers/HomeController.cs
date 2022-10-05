using Microsoft.EntityFrameworkCore.SqlServer;
using EticaretDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EticaretDemo.Dtos;

namespace EticaretDemo.Controllers
{
    public class HomeController : Controller
    {
        Context con = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
           if(login.Email=="yucelalican@hotmail.com" && login.Password=="1")
            {
                return RedirectToAction("Home","Home");
            }
            TempData["hata"] = "şifre veya parola hatali";
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Home()
        {
            List<Urun> Urunlerim= new List<Urun>();
            Urunlerim = con.Urunler.ToList();
            List<Sepet> sepetim = new List<Sepet>();
            sepetim = con.Sepet.ToList();
            HomeDto list = new HomeDto();
            list.Urunlerim = Urunlerim;
            list.Sepetim = sepetim;
            return View(list);  
        }
        [HttpPost]
        public IActionResult SepeteEkle(int id,int adet)
        {
            Urun urun = con.Urunler.Where(p => p.Id == id).FirstOrDefault();
            Sepet sepet = new Sepet();
            sepet.Adi = urun.Adi;
            sepet.Adet = adet;
            sepet.BirimFiyat = urun.BirimFiyat;
            sepet.Toplam = sepet.Adet * sepet.BirimFiyat;
            con.Sepet.Add(sepet);
            con.SaveChanges();
            return RedirectToAction("Home","Home");
        }
        public IActionResult SepettekiUrunuSil(int id)
        {
            Sepet sepet = con.Sepet.Where(p =>p.Id==id).FirstOrDefault();
            con.Sepet.Remove(sepet);
            con.SaveChanges();
            return RedirectToAction("Home","Home");
        }
     public IActionResult OdemeYap()
        {
            var result = con.Sepet.ToList();
            foreach (var item in result)
            {
                con.Sepet.Remove(item);
                con.SaveChanges();
            }
            TempData["odeme"] = "ödeme yapildi";
            return RedirectToAction("Home","Home");
        }
    }
}