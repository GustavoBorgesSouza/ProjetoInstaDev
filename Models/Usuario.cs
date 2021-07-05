using System;
using System.Collections.Generic;
using System.IO;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Usuario : Instadevbase, IUsuario
    {
        public string Email { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string FotoPerfil { get; set; }

        public List<Post> PostsUsuario { get; set; }
        public bool repetir { get; set;}

        private const string CAMINHO = "Database/Usuario.csv";
        
        public Usuario(){
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Usuario u){
            return $"{u.IdUsuario};{u.Email};{u.Nome};{u.Username};{u.Senha};{u.FotoPerfil}";
        }
        
        public void AlterarDados(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == u.IdUsuario.ToString());
            linhas.Add(Preparar(u));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Cadastrar(Usuario u)
        {
            string[] linha = {Preparar(u)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void DeletarConta(int IdUsuario)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == IdUsuario.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Usuario> LerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Usuario usuario = new Usuario();

                usuario.IdUsuario = Int32.Parse(linha[0]);
                usuario.Email = linha[1];
                usuario.Nome = linha[2];
                usuario.Username = linha[3];
                usuario.Senha = linha[4];
                usuario.FotoPerfil = linha[5];

                usuarios.Add(usuario);
            }

            return usuarios;

        }
        public List<Usuario> LerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            for (int i = 1; i <= 7; i++)
            {
                var item = linhas[i];
                string[] linha = item.Split(";");
                Usuario usuario = new Usuario();

                usuario.IdUsuario = Int32.Parse(linha[0]);
                usuario.Email = linha[1];
                usuario.Nome = linha[2];
                usuario.Username = linha[3];
                usuario.Senha = linha[4];
                usuario.FotoPerfil = linha[5];

                usuarios.Add(usuario);
                
            }

            return usuarios;

        }

        public bool VerificandoId(Int32 id){
            List<string> UsuariosCsv = LerTodasLinhasCSV("Database/Usuario.csv");
            var identificador = UsuariosCsv.Find(x => Int32.Parse(x.Split(";")[0]) == id);

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