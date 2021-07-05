using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Controllers
{
    [Route("EdicaoPerfil")]
    public class EdicaoPerfilController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioModel.LerTodos();
            return View();
        }

        [Route("Alterar")]
        public IActionResult Alterar(IFormCollection form){
            Usuario novoUsuario = new Usuario();

            novoUsuario.Nome = form[""];
            novoUsuario.Username = form[""];
            novoUsuario.Email = form[""];

            usuarioModel.Cadastrar(novoUsuario);

            ViewBag.Usuarios = usuarioModel.LerTodos();
            
            return LocalRedirect("~/Feed");
        }

        // ACHO QUE ESSE AQUI TA FUNCIONANDO
        [Route("Excluir")]
        public IActionResult Excluir(int id)
        {
            usuarioModel.DeletarConta(id);
            ViewBag.Usuarios = usuarioModel.LerTodos();

            return LocalRedirect("~/Login");
        }
    }
}
