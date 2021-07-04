using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Controllers
{
    [Route("Cadastro")]
    public class CadastroController : Controller
    {
        Usuario usuarioModel = new Usuario();

        public IActionResult Index()
        {
            ViewBag.usuarios = usuarioModel.LerUsuarios();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();
            novoUsuario.Email = form["Email"];
            novoUsuario.Nome = form["Nome"];
            novoUsuario.Username = form["Username"];
            novoUsuario.Senha = form["Senha"];

            usuarioModel.Cadastrar(novoUsuario);

            ViewBag.usuarios = usuarioModel.LerUsuarios();

            return LocalRedirect("~/Login");
        }
    }
}