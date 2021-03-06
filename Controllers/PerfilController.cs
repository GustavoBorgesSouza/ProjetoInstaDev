using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        Post postModel = new Post();
        Usuario usuarioModel = new Usuario();

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag._Username = HttpContext.Session.GetString("_Username");
            ViewBag._UserNome = HttpContext.Session.GetString("_UserNome");
            ViewBag._UserFoto = HttpContext.Session.GetString("_UserFoto");
            ViewBag._UserId = HttpContext.Session.GetString("_UserId");
            List<Post> lista = postModel.MostrarPosts();
            lista.Reverse();
            ViewBag.Posts = lista;
            return View();
        }
    }
}
