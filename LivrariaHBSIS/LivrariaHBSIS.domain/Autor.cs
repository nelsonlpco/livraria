using System.Collections.Generic;

namespace LivrariaHBSIS.domain
{
    public class Autor
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }
        private readonly IList<Livro> _livros;
        public virtual IEnumerable<Livro> Livros { get { return _livros; } }

        public Autor()
        {
            _livros = new List<Livro>();
        }
    }
}
