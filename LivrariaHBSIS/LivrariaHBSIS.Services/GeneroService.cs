using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using System.Collections.Generic;

namespace LivrariaHBSIS.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public void EditarGenero(Genero genero)
        {
            _generoRepository.Update(genero);
        }

        public void IncluirGenero(Genero genero)
        {
            _generoRepository.Save(genero);
        }

        public IEnumerable<Genero> ListarGeneros()
        {
            return _generoRepository.GetAll();
        }

        public Genero RecuperarGeneroPorId(long id)
        {
            return _generoRepository.GetById(id);
        }

        public void RemoverGenero(Genero genero)
        {
            _generoRepository.Delete(genero);
        }
    }
}
