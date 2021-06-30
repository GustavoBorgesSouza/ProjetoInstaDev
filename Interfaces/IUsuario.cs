using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(Usuario u);
        void Logar(Usuario u);
        void AlterarDados(Usuario u);
        void DeletarConta(Usuario u);
         
    }
}