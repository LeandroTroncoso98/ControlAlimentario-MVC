using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Diagnostics.Contracts;

namespace ConsumoAlimentario.Controllers
{
    public class ConsumoDiariosController : Controller
    {
        private readonly IConsumoDiarioRepository _consumoDiarioRepository;
        private readonly IAlimentoCargadoRepository _alimentoCargadoRepository;
        public ConsumoDiariosController(IConsumoDiarioRepository consumoDiarioRepository, IAlimentoCargadoRepository alimentoCargadoRepository)
        {
            _consumoDiarioRepository = consumoDiarioRepository;
            _alimentoCargadoRepository= alimentoCargadoRepository;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { Data = _consumoDiarioRepository.GetAll() });
        }
        [HttpGet]
        public IActionResult ConsumoDelDia()
        {
            ConsumoDiario consumoDiario = new ConsumoDiario()
            {
                Fecha = DateTime.Now
            };
            if (!_consumoDiarioRepository.Existe(consumoDiario.Fecha))
            {
                _consumoDiarioRepository.Crear(consumoDiario);
                _consumoDiarioRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));       
        }
        [HttpGet]
        public IActionResult AdministrarConsumoDiario(int id)
        {
            ConsumoDiarioAlimentoVM consumoDiarioAlimentoVM = new ConsumoDiarioAlimentoVM()
            {
                ConsumoDiario = _consumoDiarioRepository.Get(id)
            };
            if (consumoDiarioAlimentoVM.ConsumoDiario == null)
                return NotFound();
            consumoDiarioAlimentoVM.ConsumoDiario.ListaAlimentos = _alimentoCargadoRepository.GetListAlimentoCargadoFromId(id);
            return View(consumoDiarioAlimentoVM);
        }
        
    }
}
