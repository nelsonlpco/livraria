using System.Collections.Generic;

namespace LivrariaHBSIS.domain.Interfaces.Services
{
    public interface IAutorService
    {
        void IncluirAutor(Autor autor);
        void EditarAutor(Autor autor);
        void RemoverAutor(Autor autor);
        IEnumerable<Autor> ListarAutores();
        Autor RecuperarAutorPorId(long id);
    }
}
