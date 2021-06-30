using System.Collections.Generic;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Post : Instadevbase, IPost
    {
      public string Descricao { get; set; }
      public string FotoPost { get; set; }
      public Usuario NomeUsuario { get; set; }

    private const string CAMINHO = "Database/Usuario.csv";
        
        public Post(){
            CriarPastaEArquivo(CAMINHO);
        }

        public void CriarPost(Post p)
        {
            throw new System.NotImplementedException();
        }

        public List<Post> MostrarPosts()
        {
            throw new System.NotImplementedException();
        }
    }
}