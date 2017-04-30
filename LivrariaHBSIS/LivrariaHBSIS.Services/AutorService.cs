using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using System.Collections.Generic;

namespace LivrariaHBSIS.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public void EditarAutor(Autor autor)
        {
            _autorRepository.Update(autor);
        }

        public void IncluirAutor(Autor autor)
        {
            _autorRepository.Save(autor);
        }

        public IEnumerable<Autor> ListarAutores()
        {
            return _autorRepository.GetAll();
        }

        public Autor RecuperarAutorPorId(long id)
        {
            return _autorRepository.GetById(id);
        }

        public void RemoverAutor(Autor autor)
        {
            _autorRepository.Delete(autor);
        }
    }
}
