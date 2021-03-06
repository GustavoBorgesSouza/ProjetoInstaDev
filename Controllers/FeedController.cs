using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Post postModel = new Post();
        Usuario usuarioModel = new Usuario();
        Random IdAleatorio = new Random();
        bool repetir;

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
            ViewBag.Usuarios = usuarioModel.LerTodos();

            return View();
        }

        [Route("Postar")]
        public IActionResult Postar(IFormCollection form){
            Post novoPost = new Post();

             do
            {
                Int32 IdPost = IdAleatorio.Next();
                repetir = postModel.VerificandoId(IdPost);

            } while(repetir == true);
            novoPost.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));
            novoPost.UsernameUsuario = HttpContext.Session.GetString("_Username");
            novoPost.FotoUsuario = HttpContext.Session.GetString("_UserFoto");
            novoPost.IdPost = IdAleatorio.Next();
            novoPost.Descricao = form["Descricao"];

            if (form.Files.Count > 0)
            {
                var file = form.Files[0]; //armazena o arquivo do formulario dentro da variavel file
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Posts"); //cria a variavel pasta

                if (!Directory.Exists(folder)) //cria a pasta
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/", folder, file.FileName); //cria o caminho na variavel

                using (var stream = new FileStream(path, FileMode.Create)) //criando e salvando o arquivo
                {
                    file.CopyTo(stream);//copia o arquivo no stream 
                }

                novoPost.FotoPost = file.FileName; //recebe o nome do arquivo

            } else
            {
                novoPost.FotoPost = "padrao.png"; //padrao.png ?? uma img padrao que ficar?? salva para quem n??o colocar nenhuma imagem
            }

            postModel.CriarPost(novoPost);

            ViewBag.Posts = postModel.MostrarPosts();

            return LocalRedirect("~/Feed/Index");

        }

        

        
        

        
    }
}