using System.Collections.Generic;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(Usuario u);
        // void Logar(Usuario u);
        void AlterarDados(Usuario u);
        void DeletarConta(int Id);

        List<Usuario> LerUsuarios();
         
    }
}
