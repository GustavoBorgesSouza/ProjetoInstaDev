using System.Collections.Generic;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Usuario : Instadevbase, IUsuario
    {
        public string Email { get; set; }
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string FotoPerfil { get; set; }

        public List<Post> PostsUsuario { get; set; }

        private const string CAMINHO = "Database/Usuario.csv";
        
        public Usuario(){
            CriarPastaEArquivo(CAMINHO);

        }
        
        public void AlterarDados(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarConta(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public void Logar(Usuario u)
        {
            throw new System.NotImplementedException();
        }
    }
}