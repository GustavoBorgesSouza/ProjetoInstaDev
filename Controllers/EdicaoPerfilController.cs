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
            ViewBag._Username = HttpContext.Session.GetString("_Username");
            ViewBag._UserId = HttpContext.Session.GetString("_UserId");
            ViewBag._UserNome = HttpContext.Session.GetString("_UserNome");
            ViewBag._UserFoto = HttpContext.Session.GetString("_UserFoto");
            ViewBag._UserEmail = HttpContext.Session.GetString("_UserEmail");
            ViewBag._UserSenha = HttpContext.Session.GetString("_UserSenha");
            
            return View();
        }

        [Route("Editar")]
        public IActionResult Editar(IFormCollection form){
            Usuario novoUsuario = new Usuario();

            novoUsuario.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));
            novoUsuario.Senha = HttpContext.Session.GetString("_UserSenha");
            novoUsuario.Nome = form["Nome"];
            novoUsuario.Username = form["Username"];
            novoUsuario.Email = form["Email"];

            if (form.Files.Count > 0)
            {
                var file = form.Files[0]; //armazena o arquivo do formulario dentro da variavel file
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Usuarios"); //cria a variavel pasta

                if (!Directory.Exists(folder)) //cria a pasta
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/", folder, file.FileName); //cria o caminho na variavel

                using (var stream = new FileStream(path, FileMode.Create)) //criando e salvando o arquivo
                {
                    file.CopyTo(stream);//copia o arquivo no stream 
                }

                novoUsuario.FotoPerfil = file.FileName; //recebe o nome do arquivo

            } else
            {
                novoUsuario.FotoPerfil = "padraoperfil.png"; //padrao.png é uma img padrao que ficará salva para quem não colocar nenhuma imagem
            }

            HttpContext.Session.SetString("_Username", novoUsuario.Username);
            HttpContext.Session.SetString("_UserNome", novoUsuario.Nome);
            HttpContext.Session.SetString("_UserFoto", novoUsuario.FotoPerfil);

            usuarioModel.AlterarDados(novoUsuario);

            ViewBag.Usuarios = usuarioModel.LerTodos();


            return LocalRedirect("~/Perfil/Index");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            usuarioModel.DeletarConta(id);
            ViewBag.Usuarios = usuarioModel.LerTodos();

            return LocalRedirect("~/Home/Index");
            
        }
    }
}