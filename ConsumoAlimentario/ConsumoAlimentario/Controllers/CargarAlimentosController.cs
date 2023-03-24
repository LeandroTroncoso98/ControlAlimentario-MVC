using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoAlimentario.Controllers
{
    public class CargarAlimentosController : Controller
    {
        private readonly IAlimentoCargadoRepository _alimentoCargadoRepository;
        private readonly IAlimentoRepository _alimentoRepository;
        private readonly IConsumoDiarioRepository _consumoDiarioRepository;
        public CargarAlimentosController(IAlimentoCargadoRepository alimentoCargadoRepository, IConsumoDiarioRepository consumoDiarioRepository, IAlimentoRepository alimentoRepository)
        {
            _alimentoCargadoRepository = alimentoCargadoRepository;
            _consumoDiarioRepository = consumoDiarioRepository;
            _alimentoRepository = alimentoRepository;
        }

        public IActionResult Cargar(int id)
        {
            ConsumoDiarioAlimentoVM consumoDiarioAlimentoVM = new ConsumoDiarioAlimentoVM()
            {
                Alimentos = _alimentoRepository.GetAll(),
                ConsumoDiario = _consumoDiarioRepository.Get(id)
            };
            return View(consumoDiarioAlimentoVM);
        }
      
    }
}
