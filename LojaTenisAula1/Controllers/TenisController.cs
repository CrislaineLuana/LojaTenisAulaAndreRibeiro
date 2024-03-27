using LojaTenisAula1.Services.Tenis;
using Microsoft.AspNetCore.Mvc;

namespace LojaTenisAula1.Controllers
{
    public class TenisController : Controller
    {
        private readonly ITenisInterface _tenisInterface;
        public TenisController(ITenisInterface tenisInterface)
        {
            _tenisInterface = tenisInterface;
        }

        public async Task<IActionResult> Index()
        {
            var tenis = await _tenisInterface.BuscarTenis();
            return View(tenis);
        }


        public async Task<IActionResult> Detalhes(int? id)
        {
            if(id != null)
            {
                var tenis = await _tenisInterface.BuscarTenisPorId(id);
                return View(tenis);
            }

            return RedirectToAction("Index");
            
        }
    }
}
