using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Controllers
{
    [Route("Home")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }

        Usuario usuarioModel = new Usuario();

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> usuariosCSV = usuarioModel.LerTodasLinhasCSV("Database/usuario.csv");

            var logado = usuariosCSV.Find(
                x =>
                x.Split(";")[1] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_UserId", logado.Split(";")[0]);
                HttpContext.Session.SetString("_UserSenha", logado.Split(";")[4]);
                HttpContext.Session.SetString("_Username", logado.Split(";")[3]);
                HttpContext.Session.SetString("_UserNome", logado.Split(";")[2]);
                HttpContext.Session.SetString("_UserFoto", logado.Split(";")[5]);
                

                return LocalRedirect("~/Feed/Index");

            }
            else
            {
                return LocalRedirect("~/Home/Index");
            }
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserId");
            HttpContext.Session.Remove("_Username");
            HttpContext.Session.Remove("_UserNome");
            HttpContext.Session.Remove("_UserFoto");
            HttpContext.Session.Remove("_UserSenha");

            return LocalRedirect("~/Home/Index");
        }
    }
}