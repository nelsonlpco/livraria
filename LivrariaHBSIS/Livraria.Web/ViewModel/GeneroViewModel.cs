using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.ViewModel
{
    public class GeneroViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve possuir no maximo 100 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do nome deve ser 4 caracteres")]
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