using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.ViewModels
{
    public class AutorViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve possuir no maximo 150 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do nome deve ser 2 caracteres")]
        public string Nome { get; set; }

        public AutorViewModel AutorToAutorViewModel(Autor autor)
        {
            return new AutorViewModel
            {
                Id = autor.Id,
                Nome = autor.Nome
            };
        }

        public Autor AutorViewModelToAutor()
        {
            return new Autor
            {
                Id = this.Id,
                Nome = this.Nome
            };
        }
    }
}