using LivrariaHBSIS.domain;
using System.ComponentModel.DataAnnotations;

namespace LivrariaHBSIS.Web.ViewModel
{
    public class EditoraViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve possuir no máximo 150 caracteres.")]
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