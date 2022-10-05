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

       
    }
}