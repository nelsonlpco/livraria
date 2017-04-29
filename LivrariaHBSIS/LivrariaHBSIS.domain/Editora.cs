using System.Collections.Generic;

namespace LivrariaHBSIS.domain
{
    public class Editora
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        private readonly IList<Livro> _livros;
        public virtual IEnumerable<Livro> Livros { get { return _livros; } }
        public Editora()
        {
            _livros = new List<Livro>();
        }
    }
}
