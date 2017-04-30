using LivrariaHBSIS.domain;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Web.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace LivrariaHBSIS.Web.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        private readonly IAutorService _autorService;
        private readonly IGeneroService _generoService;
        private readonly IEditoraService _editoraService;
        public LivroController(ILivroService livroService, IAutorService autorService, IGeneroService generoService, IEditoraService editoraService)
        {
            _livroService = livroService;
            _autorService = autorService;
            _generoService = generoService;
            _editoraService = editoraService;
        }
        public ActionResult Index()
        {
            var livrosViewModel = _livroService.ListarLivros().Select(livro => new LivroViewModel
            {
                Id = livro.Id,
                AnoPublicacao = livro.AnoPublicacao,
                AutorPrincipal = livro.AutorPrincipal,
                Descricao = livro.Descricao,
                EditoraPublicacao = livro.EditoraPublicacao,
                GeneroLivro = livro.GeneroLivro,
                Isbn = livro.Isbn,
                Titulo = livro.Titulo
            }).OrderBy(l => l.Titulo).ToList();

            return View(livrosViewModel);
        }

        public ActionResult Details(int id)
        {
            var livro = _livroService.RecuperarLivroPorId(id);
            var livroViewModel = new LivroViewModel
            {
                Id = livro.Id,
                AnoPublicacao = livro.AnoPublicacao,
                AutorPrincipal = livro.AutorPrincipal,
                Descricao = livro.Descricao,
                EditoraPublicacao = livro.EditoraPublicacao,
                GeneroLivro = livro.GeneroLivro,
                Isbn = livro.Isbn,
                Titulo = livro.Titulo,
                AutorSelecionado = livro.AutorPrincipal == null ? 0 : livro.AutorPrincipal.Id,
                GeneroSelecionado = livro.GeneroLivro == null ? 0 : livro.GeneroLivro.Id,
                EditoraSelecionada = livro.EditoraPublicacao == null ? 0 : livro.EditoraPublicacao.Id
            };
            return View(livroViewModel);
        }

        public ActionResult Create()
        {
            CarregarItensParaSelect();
            return View();
        }

        [HttpPost]
        public ActionResult Create(LivroViewModel livroViewModel)
        {
            try
            {
                var livro = new Livro
                {
                    AnoPublicacao = livroViewModel.AnoPublicacao,
                    Descricao = livroViewModel.Descricao,
                    EditoraPublicacao = _editoraService.RecuperarEditoraPorId(livroViewModel.EditoraSelecionada),
                    GeneroLivro = _generoService.RecuperarGeneroPorId(livroViewModel.GeneroSelecionado),
                    AutorPrincipal = _autorService.RecuperarAutorPorId(livroViewModel.AutorSelecionado),
                    Isbn = livroViewModel.Isbn,
                    Id = livroViewModel.Id,
                    Titulo = livroViewModel.Titulo
                };
                _livroService.IncluirLivro(livro);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
                GeneroLivro = livro.GeneroLivro,
                Isbn = livro.Isbn,
                Titulo = livro.Titulo,
                AutorSelecionado = livro.AutorPrincipal == null ? 0 : livro.AutorPrincipal.Id,
                GeneroSelecionado = livro.GeneroLivro == null ? 0 : livro.GeneroLivro.Id,
                EditoraSelecionada = livro.EditoraPublicacao == null ? 0 : livro.EditoraPublicacao.Id
            };
            CarregarItensParaSelect();
            return View(livroViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, LivroViewModel livroViewModel)
        {
            try
            {
                var livro = new Livro
                {
                    AnoPublicacao = livroViewModel.AnoPublicacao,
                    Descricao = livroViewModel.Descricao,
                    EditoraPublicacao = _editoraService.RecuperarEditoraPorId(livroViewModel.EditoraSelecionada),
                    GeneroLivro = _generoService.RecuperarGeneroPorId(livroViewModel.GeneroSelecionado),
                    AutorPrincipal = _autorService.RecuperarAutorPorId(livroViewModel.AutorSelecionado),
                    Isbn = livroViewModel.Isbn,
                    Id = livroViewModel.Id,
                    Titulo = livroViewModel.Titulo
                };
                _livroService.EditarLivro(livro);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
                GeneroLivro = livro.GeneroLivro,
                Isbn = livro.Isbn,
                Titulo = livro.Titulo
            };
            return View(livroViewModel);
        }

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

        private void CarregarItensParaSelect()
        {
            var autores = _autorService
               .ListarAutores()
               .Select(autor => new SelectListItem { Value = autor.Id.ToString(), Text = autor.Nome })
               .ToList();
            ViewBag.SelectListAutores = new SelectList(autores, "Value", "Text");

            var generos = _generoService.ListarGeneros().Select(genero => new SelectListItem { Value = genero.Id.ToString(), Text = genero.Descricao }).ToList();
            ViewBag.SelectListGeneros = new SelectList(generos, "Value", "Text");

            var editoras = _editoraService.ListarEditoras().Select(editora => new SelectListItem { Value = editora.Id.ToString(), Text = editora.Nome }).ToList();
            ViewBag.SelectListEditoras = new SelectList(editoras, "Value", "Text");

        }
    }
}
