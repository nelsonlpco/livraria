using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.ViewModel
{
    public class LivroViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve possuir no maximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do nome deve ser 4 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve possuir no maximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do nome deve ser 4 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Genero é obrigatório.")]
        public Genero genero { get; set; }
        [Required(ErrorMessage = "O campo Autor Principal é obrigatório.")]
        public Autor AutorPrincipal { get; set; }
        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        public Editora EditoraPublicacao { get; set; }
        [Required(ErrorMessage = "O campo ano de publicação é obrigatório.")]
        public int AnoPublicacao { get; set; }
        [Required(ErrorMessage = "O campo ISBN é obrigatório.")]
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
                genero = this.genero,
                Isbn = this.Isbn,
                Titulo = this.Titulo
            };
        }
    }
}