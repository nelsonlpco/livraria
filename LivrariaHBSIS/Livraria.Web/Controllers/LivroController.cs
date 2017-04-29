using Livraria.Web.ViewModel;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Services;
using System.Linq;
using System.Web.Mvc;

namespace Livraria.Web.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController()
        {
            _livroService = new LivroService();
        }
        // GET: Livro
        public ActionResult Index()
        {
            var livrosViewModel = _livroService.ListarLivros().Select(l => new LivroViewModel
            {
                Id = l.Id,
                AnoPublicacao = l.AnoPublicacao,
                AutorPrincipal = l.AutorPrincipal,
                Descricao = l.Descricao,
                EditoraPublicacao = l.EditoraPublicacao,
                genero = l.genero,
                Isbn = l.Isbn,
                Titulo = l.Titulo
            }).OrderBy(l => l.Titulo).ToList();

            return View(livrosViewModel);
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livroViewModel)
        {
            try
            {

                _livroService.IncluirLivro(livroViewModel.LivroViewModelToLivro());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(long id)
        {
            var livro = _livroService.RecuperarLivroPorId(id);
            var livroViewModel = new LivroViewModel
            {
                Id = livro.Id,
                AnoPublicacao = livro.AnoPublicacao,
                AutorPrincipal = livro.AutorPrincipal,
                Descricao = livro.Descricao,
                EditoraPublicacao = livro.EditoraPublicacao,
                genero = livro.genero,
                Isbn = livro.Isbn,
                Titulo = livro.Titulo
            };

            return View(livroViewModel);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LivroViewModel livroViewModel)
        {
            try
            {
                _livroService.EditarLivro(livroViewModel.LivroViewModelToLivro());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(long id)
        {
            var livro = _livroService.RecuperarLivroPorId(id);
            var livroViewModel = new LivroViewModel
            {
                Id = livro.Id,
                AnoPublicacao = livro.AnoPublicacao,
                AutorPrincipal = livro.AutorPrincipal,
                Descricao = livro.Descricao,
                EditoraPublicacao = livro.EditoraPublicacao,
                genero = livro.genero,
                Isbn = livro.Isbn,
                Titulo = livro.Titulo
            };
            return View(livroViewModel);
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LivroViewModel livroViewModel)
        {
            try
            {
                _livroService.RemoverLivro(livroViewModel.LivroViewModelToLivro());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
