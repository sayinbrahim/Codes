using MapboxExample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapboxExample.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAstrologyService _astrologyService;

        public HomeController(IAstrologyService astrologyService)
        {
            _astrologyService = astrologyService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveData(string name, string birthdate, string location)
        {
            // Verileri kaydetme işlemleri burada gerçekleştirilebilir
            // Örneğin, veritabanına kaydedebilirsiniz

            return Ok();
        }
    }
}
