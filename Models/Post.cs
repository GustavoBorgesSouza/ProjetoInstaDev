using System;
using System.Collections.Generic;
using System.IO;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Post : Instadevbase, IPost
    {
        public string Descricao { get; set; }
        public string FotoPost { get; set; }
        public int IdUsuario { get; set; }
        public int IdPost { get; set; }

        private const string CAMINHO = "Database/Post.csv";

        public Post()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Post p)
        {
            return $"{p.IdPost};{p.FotoPost};{p.Descricao};{p.IdUsuario}";
        }

        public void CriarPost(Post p)
        {
            string[] linha = { Preparar(p) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Post> MostrarPosts()
        {
            List<Post> posts = new List<Post>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Post post = new Post();

                post.IdPost = Int32.Parse(linha[0]);
                post.FotoPost = linha[1];
                post.Descricao = linha[2];
                post.IdUsuario = Int32.Parse(linha[3]);

                posts.Add(post);

            }

            return posts;

        }
        public List<Post> MostrarPost(Usuario u)
        {
            List<Post> posts = new List<Post>();
            string[]linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Post post = new Post();

                if (post.IdUsuario == u.IdUsuario)
                {
                    post.IdPost = Int32.Parse(linha[0]);
                    post.FotoPost = linha[1];
                    post.Descricao = linha[2];
                    post.IdUsuario = Int32.Parse(linha[3]);

                    posts.Add(post);
                }
                
            }

            return posts;
            
        }

    }
}