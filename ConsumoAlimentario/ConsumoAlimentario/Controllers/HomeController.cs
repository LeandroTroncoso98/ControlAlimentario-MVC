using ConsumoAlimentario.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsumoAlimentario.Utilidad;
using ConsumoAlimentario.AccesoDatos.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ConsumoAlimentario.AccesoDatos.Repository.IRepository;

namespace ConsumoAlimentario.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public HomeController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrarse(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(_usuarioRepository.ExisteUsuario(usuario.Email))
                {
                    ViewData["Mensaje"] = "Ese email ya se encuentra en uso";
                    return View();
                }
                usuario.Password = Encriptador.EncriptarClave(usuario.Password);
                Usuario usuarioCreado = _usuarioRepository.SaveUsuario(usuario);
                if (usuarioCreado.Usuario_Id > 0)
                    return RedirectToAction(nameof(IniciarSesion));
            }
            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }
        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IniciarSesion(string email ,string password)
        {
            if(email == null||password == null)
            {
                ViewData["Mensaje"] = "Debe ingresar el mail y contraseña";
                return View();
            }
            if (ModelState.IsValid)
            {
                Usuario usuarioDB = _usuarioRepository.GetUsuario(email, Encriptador.EncriptarClave(password));

                if (usuarioDB == null)
                {
                    ViewData["Mensaje"] = "No se encontraron coincidencias";
                    return View();
                }
                List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioDB.Email)
            };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                    );
                return RedirectToAction("Index", "ConsumoDiarios",new {id = usuarioDB.Usuario_Id});
            }
            return View();
        }
        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(IniciarSesion));
        }
    }
}