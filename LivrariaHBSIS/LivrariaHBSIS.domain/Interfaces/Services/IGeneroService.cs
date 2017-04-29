using System.Collections.Generic;

namespace LivrariaHBSIS.domain.Interfaces.Services
{
    public interface IGeneroService
    {
        void IncluirGenero(Genero genero);
        void RemoverGenero(Genero genero);
        void EditarGenero(Genero genero);
        IEnumerable<Genero> ListarGeneros();
        Genero RecuperarGeneroPorId(long id);
    }
}
