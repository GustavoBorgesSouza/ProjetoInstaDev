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
        public string UsernameUsuario { get; set; }
        public string FotoUsuario { get; set; }
        public int IdPost { get; set; }
        public bool repetir { get; set; }

        private const string CAMINHO = "Database/Post.csv";

        public Post()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Post p)
        {
            return $"{p.IdPost};{p.FotoPost};{p.Descricao};{p.UsernameUsuario};{FotoUsuario}";
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
                post.UsernameUsuario = linha[3];
                post.FotoUsuario = linha[4];


                posts.Add(post);

            }

            return posts;

        }
        public List<Post> MostrarPosts(Usuario u)
        {
            List<Post> posts = new List<Post>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Post post = new Post();

                if (post.UsernameUsuario == u.Username)
                {
                    post.IdPost = Int32.Parse(linha[0]);
                    post.FotoPost = linha[1];
                    post.Descricao = linha[2];
                    post.UsernameUsuario = linha[3];
                    post.FotoUsuario = linha[4];

                    posts.Add(post);
                }

            }

            return posts;

        }

        public bool VerificandoId(Int32 id)
        {
            List<string> PostsCsv = LerTodasLinhasCSV("Database/Post.csv");
            var identificador = PostsCsv.Find(x => Int32.Parse(x.Split(";")[0]) == id);

            if (identificador != null)
            {
                repetir = true;
            }
            else if (identificador == null)
            {
                repetir = false;
            }

            return repetir;
        }

    }
}