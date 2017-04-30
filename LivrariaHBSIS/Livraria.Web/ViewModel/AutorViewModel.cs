using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace LivrariaHBSIS.Web.ViewModels
{
    public class AutorViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve possuir no máximo 150 caracteres.")]
        public string Nome { get; set; }
        public AutorViewModel()
        {

        }
        public AutorViewModel(long id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}