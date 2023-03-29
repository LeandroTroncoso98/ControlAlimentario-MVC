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
                Alimentos = _alimentoRepository.GetListaAlimentos(),
                ConsumoDiario = _consumoDiarioRepository.Get(id)
            };
            if (consumoDiarioAlimentoVM.ConsumoDiario == null)
                return NotFound();
            ViewBag.Data = id;
            return View(consumoDiarioAlimentoVM);
        }

        [HttpPost]
        public IActionResult Cargar(ConsumoDiarioAlimentoVM consumoDiarioAlimentoVM)
        {
            if (ModelState.IsValid)
            {
                var alimento = _alimentoRepository.Get(consumoDiarioAlimentoVM.AlimentoCargado.Alimento_Id);
                var alimentoCargado = _alimentoCargadoRepository.CalcularAlimentoCargado(alimento, consumoDiarioAlimentoVM.AlimentoCargado.Cantidad, consumoDiarioAlimentoVM.AlimentoCargado.ConsumoDiario_Id);
                _alimentoCargadoRepository.Crear(alimentoCargado);
                _alimentoCargadoRepository.Save();
                _consumoDiarioRepository.ActulizarConsumoDiario(alimentoCargado.ConsumoDiario_Id);
                _consumoDiarioRepository.Save();
                return RedirectToAction("AdministrarConsumoDiario", "ConsumoDiarios", new { id = alimentoCargado.ConsumoDiario_Id });
            }
            consumoDiarioAlimentoVM.Alimentos = _alimentoRepository.GetListaAlimentos();
            return View(consumoDiarioAlimentoVM);
        }
        [HttpGet]
        public IActionResult EliminarAlimentoCargado(int id)
        {
            var alimento = _alimentoCargadoRepository.Get(id);
            if (alimento == null)
                return NotFound();
            var alimentoAQuitar = alimento;
            _alimentoCargadoRepository.Eliminar(alimento);
            _alimentoCargadoRepository.Save();
            _consumoDiarioRepository.ActulizarConsumoDiario(alimentoAQuitar.ConsumoDiario_Id);
            return RedirectToAction("AdministrarConsumoDiario", "ConsumoDiarios", new { id = alimentoAQuitar.ConsumoDiario_Id });
        }
    }
}
