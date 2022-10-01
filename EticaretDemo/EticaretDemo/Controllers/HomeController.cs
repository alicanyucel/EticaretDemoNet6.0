using EticaretDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EticaretDemo.Controllers
{
    public class HomeController : Controller
    {

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
            return View();
        }

       
    }
}