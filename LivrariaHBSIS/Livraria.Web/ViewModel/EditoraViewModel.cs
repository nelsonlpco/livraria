using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.ViewModel
{
    public class EditoraViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve possuir no maximo 150 caracteres.")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do nome deve ser 2 caracteres")]
        public string Nome { get; set; }

        public EditoraViewModel()
        {

        }

        public EditoraViewModel(long id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public Editora EditoraViewModelToEditora()
        {
            return new Editora
            {
                Id = this.Id,
                Nome = this.Nome
            };
        }
    }
}