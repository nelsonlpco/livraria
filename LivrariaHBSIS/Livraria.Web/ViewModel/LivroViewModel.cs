using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.ViewModel
{
    public class LivroViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve possuir no maximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do nome deve ser 4 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve possuir no maximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do nome deve ser 4 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        [Display(Name = "Gênero")]
        public long GeneroSelecionado { get; set; }
        public Genero GeneroLivro { get; set; }
        [Required(ErrorMessage = "O campo Autor principal é obrigatório.")]
        [Display(Name = "Autor principal")]
        public long AutorSelecionado { get; set; }
        public Autor AutorPrincipal { get; set; }
        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        [Display(Name = "Editora")]
        public long EditoraSelecionada { get; set; }
        public Editora EditoraPublicacao { get; set; }
        [Required(ErrorMessage = "O campo ano de publicação é obrigatório.")]
        [Display(Name = "Ano de publicação")]
        public int AnoPublicacao { get; set; }
        [Required(ErrorMessage = "O campo ISBN é obrigatório.")]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        public Livro LivroViewModelToLivro()
        {
            return new Livro
            {
                Id = this.Id,
                AnoPublicacao = this.AnoPublicacao,
                AutorPrincipal = this.AutorPrincipal,
                Descricao = this.Descricao,
                EditoraPublicacao = this.EditoraPublicacao,
                GeneroLivro = this.GeneroLivro,
                Isbn = this.Isbn,
                Titulo = this.Titulo
            };
        }
    }
}