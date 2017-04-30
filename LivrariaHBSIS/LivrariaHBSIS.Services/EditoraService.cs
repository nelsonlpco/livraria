using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using System.Collections.Generic;

namespace LivrariaHBSIS.Services
{
    public class EditoraService : IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;
        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }
        public void EditarEditora(Editora editora)
        {
            _editoraRepository.Update(editora);
        }

        public void IncluirEditora(Editora editora)
        {
            _editoraRepository.Save(editora);
        }

        public IEnumerable<Editora> ListarEditoras()
        {
            return _editoraRepository.GetAll();
        }

        public Editora RecuperarEditoraPorId(long id)
        {
            return _editoraRepository.GetById(id);
        }

        public void RemoverEditora(Editora editora)
        {
            _editoraRepository.Delete(editora);
        }
    }
}
