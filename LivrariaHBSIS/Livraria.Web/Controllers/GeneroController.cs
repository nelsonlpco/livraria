using Livraria.Web.ViewModel;
using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;

        public GeneroController()
        {
            _generoService = new GeneroService();
        }

        public ActionResult Index()
        {
            var generosViewModel = _generoService
                .ListarGeneros()
                .Select(g => new GeneroViewModel
                {
                    Id = g.Id,
                    Descricao = g.Descricao
                }).ToList();
            return View(generosViewModel);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new GeneroViewModel());
        }

        [HttpPost]
        public ActionResult Create(GeneroViewModel generoViewModel)
        {
            try
            {
                _generoService.IncluirGenero(generoViewModel.GeneroViewModelToGenero());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var genero = _generoService.RecuperarGeneroPorId(id);
            return View(new GeneroViewModel(genero.Id, genero.Descricao));
        }

        [HttpPost]
        public ActionResult Edit(int id, GeneroViewModel generoViewModel)
        {
            try
            {
                _generoService.EditarGenero(generoViewModel.GeneroViewModelToGenero());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(long id)
        {
            var genero = _generoService.RecuperarGeneroPorId(id);
            return View(new GeneroViewModel { Id = genero.Id, Descricao = genero.Descricao });
        }

        [HttpPost]
        public ActionResult Delete(int id, GeneroViewModel generoViewModel)
        {
            try
            {
                _generoService.RemoverGenero(generoViewModel.GeneroViewModelToGenero());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
