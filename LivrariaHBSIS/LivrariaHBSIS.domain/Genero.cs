using System.Collections;
using System.Collections.Generic;

namespace LivrariaHBSIS.domain
{
    public class Genero
    {
        public virtual long Id { get; set; }
        public virtual string Descricao { get; set; }

        private readonly IList<Livro> _livros;
        public virtual IEnumerable<Livro> Livros { get { return _livros; } }

        public Genero()
        {
            _livros = new List<Livro>();
        }
    }
}
