using Livraria.Web.ViewModels;
using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Services;
using System.Linq;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;
        public AutorController()
        {
            _autorService = new AutorService();
        }

        public ActionResult Index()
        {
            var autoresViewModel = _autorService.ListarAutores()
                .Select(autor => new AutorViewModel(autor.Id, autor.Nome)
                )
                .ToList();
            return View(autoresViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AutorViewModel autorViewModel)
        {
            try
            {
                var autor = new Autor
                {
                    Id = autorViewModel.Id,
                    Nome = autorViewModel.Nome
                };

                _autorService.IncluirAutor(autor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var autor = _autorService.RecuperarAutorPorId(id);
            return View(new AutorViewModel(autor.Id, autor.Nome));
        }

        [HttpPost]
        public ActionResult Edit(int id, AutorViewModel autorViewModel)
        {
            try
            {
                var autor = new Autor
                {
                    Id = autorViewModel.Id,
                    Nome = autorViewModel.Nome
                };

                _autorService.EditarAutor(autor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var autor = _autorService.RecuperarAutorPorId(id);
            return View(new AutorViewModel(autor.Id, autor.Nome));
        }

        [HttpPost]
        public ActionResult Delete(int id, AutorViewModel autorViewModel)
        {
            try
            {
                var autor = new Autor
                {
                    Id = autorViewModel.Id,
                    Nome = autorViewModel.Nome
                };

                _autorService.RemoverAutor(autor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
