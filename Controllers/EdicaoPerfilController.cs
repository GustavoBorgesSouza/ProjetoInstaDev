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
            ViewBag._Username = HttpContext.Session.GetString("_Username");
            ViewBag._UserId = HttpContext.Session.GetString("_UserId");
            ViewBag._UserNome = HttpContext.Session.GetString("_UserNome");
            ViewBag._UserFoto = HttpContext.Session.GetString("_UserFoto");
            ViewBag._UserEmail = HttpContext.Session.GetString("_UserEmail");
            
            return View();
        }

        [Route("Editar")]
        public IActionResult Editar(IFormCollection form){
            Usuario novoUsuario = new Usuario();

            novoUsuario.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));
            novoUsuario.FotoPerfil = form["Imagem"];
            novoUsuario.Nome = form["Nome"];
            novoUsuario.Username = form["Username"];
            novoUsuario.Email = form["Email"];

            usuarioModel.AlterarDados(novoUsuario);

            ViewBag.Usuarios = usuarioModel.LerTodos();

            return LocalRedirect("~/Perfil/Index");
        }

        [Route("Excluir")]
        public IActionResult Excluir(int id){
            id = ViewBag._UserId;
            usuarioModel.DeletarConta(id);
            ViewBag.Usuarios = usuarioModel.LerTodos();

            return LocalRedirect("~/Home/Index");
            
        }
    }
}