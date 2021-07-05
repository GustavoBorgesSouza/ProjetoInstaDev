using System.Collections.Generic;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IPost
    {
       void CriarPost(Post p); 
       List<Post> MostrarPosts();
    }
}