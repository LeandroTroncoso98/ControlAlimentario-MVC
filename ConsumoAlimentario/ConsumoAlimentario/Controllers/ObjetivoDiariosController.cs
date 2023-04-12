using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoAlimentario.Controllers
{
    public class ObjetivoDiariosController : Controller
    {
        private readonly IObjetivoDiarioRepository _objetivoDiario;
        private readonly IUsuarioRepository _usuarioRepository;
        public ObjetivoDiariosController(IObjetivoDiarioRepository objetivoDiario, IUsuarioRepository usuarioRepository)
        {
            _objetivoDiario = objetivoDiario;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult NuevoObjetivo(int id)
        {
            if (_objetivoDiario.ExisteObjetivo(id))
            {
                TempData["Objetivo"] = "Usted ya posee un objetivo."; 
                return RedirectToAction("Index","ConsumoDiarios");
            }
            ViewData["IDFromUser"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult NuevoObjetivo(ObjetivoDiario objetivoDiario)
        {
            
            if (ModelState.IsValid)
            {
                if (objetivoDiario.Usuario_Id == 0)
                    return NotFound();
                _objetivoDiario.Crear(objetivoDiario);
                _objetivoDiario.Save();
                return RedirectToAction("Index", "ConsumoDiarios", new { id = objetivoDiario.Usuario_Id });
            }
            return View(objetivoDiario);
        }
        public IActionResult ModificarObjetivo(int id)
        {
            var objetivo = _objetivoDiario.GetObjetivo(id);
            if (objetivo == null)
                return NotFound();
            return View(objetivo);
        }
        [HttpPost]
        public IActionResult ModificarObjetivo(ObjetivoDiario objetivoDiario)
        {
            if (ModelState.IsValid)
            {
                _objetivoDiario.Modificar(objetivoDiario);
                return RedirectToAction("Index", "ConsumoDiarios", new { id = objetivoDiario.Usuario_Id });
            }
            return View(objetivoDiario);
        }
    }
}
