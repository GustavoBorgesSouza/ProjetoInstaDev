using System;
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
        Random numeroRandom = new Random();

        int IdAleatorio;
        bool repetir;

        [Route("Index")]
        public IActionResult Index()
        {
            // ViewBag.usuarios = usuarioModel.LerUsuarios();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();

            do
            {
                IdAleatorio = numeroRandom.Next();
                repetir = usuarioModel.VerificandoId(IdAleatorio);

            } while(repetir == true);

            novoUsuario.IdUsuario = IdAleatorio;
            novoUsuario.Email = form["Email"];
            novoUsuario.Nome = form["Nome"];
            novoUsuario.Username = form["Username"];
            novoUsuario.Senha = form["Senha"];

            
            novoUsuario.FotoPerfil = "padraoperfil.png";

            usuarioModel.Cadastrar(novoUsuario);

            ViewBag.usuarios = usuarioModel.LerTodos();

            return LocalRedirect("~/Home/Index");
        }
    }
}