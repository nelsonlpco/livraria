using System.Collections.Generic;

namespace LivrariaHBSIS.domain.Interfaces.Services
{
    public interface ILivroService
    {
        void IncluirLivro(Livro livro);
        void EditarLivro(Livro livro);
        void RemoverLivro(Livro livro);
        IEnumerable<Livro> ListarLivros();
        Livro RecuperarLivroPorId(long id);
    }
}
