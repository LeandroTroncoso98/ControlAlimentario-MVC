using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoAlimentario.Controllers
{
    public class ConsumoDiariosController : Controller
    {
        private readonly IConsumoDiarioRepository _consumoDiarioRepository;
        private readonly IAlimentoRepository _alimentoRepository;
        public ConsumoDiariosController(IConsumoDiarioRepository consumoDiarioRepository, IAlimentoRepository alimentoRepository)
        {
            _consumoDiarioRepository = consumoDiarioRepository;
            _alimentoRepository = alimentoRepository;
            
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
                ConsumoDiarios = _consumoDiarioRepository.Get(id),
                Alimentos = _alimentoRepository.GetAll()
            };
            return View(consumoDiarioAlimentoVM);
        }

    }
}
