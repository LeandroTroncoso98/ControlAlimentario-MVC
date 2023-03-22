using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace ConsumoAlimentario.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly IAlimentoRepository _alimentoRepository;
        public AlimentosController(IAlimentoRepository alimentoRepository)
        {
            _alimentoRepository = alimentoRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListaAlimentos()
        {
            return Json(new {Data = _alimentoRepository.GetAll()});
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                if (_alimentoRepository.ExisteAlimento(alimento.Nombre))
                {
                    ModelState.AddModelError("", "El nombre del alimento ya existe");
                    return View();
                }
                _alimentoRepository.Crear(alimento);
                _alimentoRepository.Save();
                return RedirectToAction(nameof(Index));
            }
                return View();                     
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var alimento = _alimentoRepository.Get(id);
            if (alimento == null)
                return NotFound();
            return View(alimento);
        }
        [HttpPost]
        public IActionResult Editar(Alimento alimento)
        {
            if (!ModelState.IsValid)
                return View();
            _alimentoRepository.Editar(alimento);
            _alimentoRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var alimento = _alimentoRepository.Get(id);
            if (alimento == null)
                return Json(new
                {
                    success = "false",
                    message = "Hubo un error al eliminar el alimento."
                });
            _alimentoRepository.Eliminar(alimento);
            _alimentoRepository.Save();
            return Json(new
            {
                success = "true",
                message = "El alimento ha sido eliminado con exíto."
            });

        }
    }
}
