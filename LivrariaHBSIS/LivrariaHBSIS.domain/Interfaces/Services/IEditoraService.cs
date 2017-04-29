using System.Collections.Generic;

namespace LivrariaHBSIS.domain.Interfaces.Services
{
    public interface IEditoraService
    {
        void IncluirEditora(Editora editora);
        void EditarEditora(Editora editora);
        void RemoverEditora(Editora editora);
        IEnumerable<Editora> ListarEditoras();
        Editora RecuperarEditoraPorId(long id);
    }
}
