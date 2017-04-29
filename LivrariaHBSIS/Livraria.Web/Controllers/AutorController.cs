using Livraria.Web.ViewModels;
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
                .Select(autor => new AutorViewModel()
                .AutorToAutorViewModel(autor))
                .ToList();
            return View(autoresViewModel);
        }

        public ActionResult Details(int id)
        {
            return View();
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
                _autorService.IncluirAutor(autorViewModel.AutorViewModelToAutor());
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
            return View(new AutorViewModel().AutorToAutorViewModel(autor));
        }

        [HttpPost]
        public ActionResult Edit(int id, AutorViewModel autorViewModel)
        {
            try
            {
                _autorService.EditarAutor(autorViewModel.AutorViewModelToAutor());
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
            return View(new AutorViewModel().AutorToAutorViewModel(autor));
        }

        [HttpPost]
        public ActionResult Delete(int id, AutorViewModel autorViewModel)
        {
            try
            {
                _autorService.RemoverAutor(autorViewModel.AutorViewModelToAutor());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
