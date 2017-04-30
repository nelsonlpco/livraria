using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace LivrariaHBSIS.Web.ViewModel
{
    public class GeneroViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve possuir no máximo 100 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public GeneroViewModel()
        {

        }

        public GeneroViewModel(long id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public Genero GeneroViewModelToGenero()
        {
            return new Genero
            {
                Id = this.Id,
                Descricao = this.Descricao
            };
        }

    }
}