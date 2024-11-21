using Microsoft.AspNetCore.Mvc;
using SportField.Data;
using SportField.Models;
using Microsoft.EntityFrameworkCore;
using SportField.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SportField.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _dbContext;
        public AccesoController(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Registrarse(UsuarioVM modelo)
        {
            if(modelo.Contrasena != modelo.ConfirmarContrasena)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            Usuario usuario = new Usuario()
            {
                NombreCompleto = modelo.NombreCompleto,
                Correo = modelo.Correo,
                Contrasena = modelo.Contrasena

            };

            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            if (usuario.IdUsuario != 0) return RedirectToAction("Login","Acceso");

            ViewData["Mensaje"] = "No se puede crear el usuario";

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult>Login(LoginVM modelo)
        {
            Usuario? usuario_encontrado = await _dbContext.Usuarios
                .Where(u =>
                u.Correo == modelo.Correo &&
                u.Contrasena == modelo.Contrasena
                ).FirstOrDefaultAsync();
                
            if(usuario_encontrado ==null)
            {
                ViewData["Mensaje"] = "No se ha encontrado usuario";

                return View();
            }

            List<Claim> claim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreCompleto)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
