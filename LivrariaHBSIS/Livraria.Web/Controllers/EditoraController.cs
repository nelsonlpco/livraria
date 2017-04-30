using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Web.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace LivrariaHBSIS.Web.Controllers
{
    public class EditoraController : Controller
    {
        private IEditoraService _editoraService;

        public EditoraController(IEditoraService editoraService)
        {
            _editoraService = editoraService;
        }
        public ActionResult Index()
        {
            var editorasViewModel = _editoraService.ListarEditoras().Select(e => new EditoraViewModel { Id = e.Id, Nome = e.Nome }).ToList();
            return View(editorasViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditoraViewModel editoraViewModel)
        {
            try
            {
                _editoraService.IncluirEditora(editoraViewModel.EditoraViewModelToEditora());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            var editora = _editoraService.RecuperarEditoraPorId(id);
            return View(new EditoraViewModel { Id = editora.Id, Nome = editora.Nome });
        }

        [HttpPost]
        public ActionResult Edit(int id, EditoraViewModel editoraViewModel)
        {
            try
            {
                _editoraService.EditarEditora(editoraViewModel.EditoraViewModelToEditora());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(long id)
        {
            var editora = _editoraService.RecuperarEditoraPorId(id);
            return View(new EditoraViewModel { Id = editora.Id, Nome = editora.Nome });
        }

        [HttpPost]
        public ActionResult Delete(int id, EditoraViewModel editoraViewModel)
        {
            try
            {
                _editoraService.RemoverEditora(editoraViewModel.EditoraViewModelToEditora());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
