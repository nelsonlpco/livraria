using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Infra.Repository;
using System.Collections.Generic;

namespace LivrariaHBSIS.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService()
        {
            _generoRepository = new GeneroRepository();
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
