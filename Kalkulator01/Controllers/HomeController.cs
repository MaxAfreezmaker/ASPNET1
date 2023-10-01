using Kalkulator01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About() 
        {
            ViewBag.Imie = "Janek";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzień dobry" : "Dobry Wieczór";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname="Kowalska"},
                new Dane {Name = "Monika", Surname="Tomczyk"},
                new Dane {Name = "Jan", Surname="Kowalski"},
            };
            return View(osoby);
        }
        public IActionResult Urodziny( Urodziny urodziny) 
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok}";
            return View(urodziny);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}