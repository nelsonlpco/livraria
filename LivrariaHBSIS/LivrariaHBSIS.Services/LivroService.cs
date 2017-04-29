using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Infra.Repository;
using System.Collections.Generic;

namespace LivrariaHBSIS.Services
{
    public class LivroService : ILivroService
    {
        private ILivroRepository _livroRepository;
        public LivroService()
        {
            _livroRepository = new LivroRepository();
        }
        public void EditarLivro(Livro livro)
        {
            _livroRepository.Update(livro);
        }

        public void IncluirLivro(Livro livro)
        {
            _livroRepository.Save(livro);
        }

        public IEnumerable<Livro> ListarLivros()
        {
            return _livroRepository.GetAll();
        }

        public Livro RecuperarLivroPorId(long id)
        {
            return _livroRepository.GetById(id);
        }

        public void RemoverLivro(Livro livro)
        {
            _livroRepository.Delete(livro);
        }
    }
}
