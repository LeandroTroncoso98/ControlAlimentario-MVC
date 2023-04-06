using ConsumoAlimentario.AccesoDatos.Repository.IRepository;
using ConsumoAlimentario.Models;
using ConsumoAlimentario.Models.ViewModel;
using ConsumoAlimentario.Utilidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Claims;

namespace ConsumoAlimentario.Controllers
{
    [Authorize]
    public class ConsumoDiariosController : Controller
    {
        private readonly IConsumoDiarioRepository _consumoDiarioRepository;
        private readonly IAlimentoCargadoRepository _alimentoCargadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IObjetivoDiarioRepository _objetivoDiarioRepository;

        public ConsumoDiariosController(IConsumoDiarioRepository consumoDiarioRepository, IAlimentoCargadoRepository alimentoCargadoRepository, IUsuarioRepository usuarioRepository, IObjetivoDiarioRepository objetivoDiarioRepository)
        {
            _consumoDiarioRepository = consumoDiarioRepository;
            _alimentoCargadoRepository = alimentoCargadoRepository;
            _usuarioRepository = usuarioRepository;
            _objetivoDiarioRepository = objetivoDiarioRepository;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string mail = "";

            mail = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).FirstOrDefault();
            var usuario = _usuarioRepository.GetForEmail(mail);
            if (usuario == null)
                return NotFound();
            ViewData["Email"] = mail;
            ConsumoDiarioUsuarioVM consumoDiarioUsuarioVM = new ConsumoDiarioUsuarioVM
            {
                ListaConsumo = _consumoDiarioRepository.GetForUserId(usuario.Usuario_Id),
                Usuario = _usuarioRepository.GetForEmail((string)ViewData["Email"])
            };
            return View(consumoDiarioUsuarioVM);
        }

        [HttpGet]
        public IActionResult ConsumoDelDia(int id)
        {
            ConsumoDiario consumoDiario = new ConsumoDiario()
            {
                Fecha = DateTime.Now,
                Usuario_Id = id
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
            consumoDiarioAlimentoVM.ObjetivoDiario = _objetivoDiarioRepository.GetObjetivo(consumoDiarioAlimentoVM.ConsumoDiario.Usuario_Id);
            CalcularPorcentual calcularPorcentual = new CalcularPorcentual();
            consumoDiarioAlimentoVM.PorcentualObjetivoDiario = calcularPorcentual.Calcular(consumoDiarioAlimentoVM.ObjetivoDiario, consumoDiarioAlimentoVM.ConsumoDiario);
            return View(consumoDiarioAlimentoVM);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var consumoDiario = _consumoDiarioRepository.Get(id);
            if (consumoDiario is null)
                return NotFound();
            _consumoDiarioRepository.Eliminar(consumoDiario);
            _consumoDiarioRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
