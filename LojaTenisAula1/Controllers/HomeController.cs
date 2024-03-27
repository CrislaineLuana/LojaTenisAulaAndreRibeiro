using LojaTenisAula1.Models;
using LojaTenisAula1.Services.Tenis;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaTenisAula1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITenisInterface _tenisInterface;
        public HomeController(ITenisInterface tenisInterface)
        {
            _tenisInterface = tenisInterface;
        }

        public async Task<IActionResult> Index()
        {
            var tenis = await _tenisInterface.BuscarTenis();
            return View(tenis);
        }

        
    }
}
