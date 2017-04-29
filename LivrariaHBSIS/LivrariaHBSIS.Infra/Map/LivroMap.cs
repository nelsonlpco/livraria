using FluentNHibernate.Mapping;
using LivrariaHBSIS.domain;

namespace LivrariaHBSIS.Infra.Map
{
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.Titulo);
            Map(m => m.Descricao);
            Map(m => m.AnoPublicacao);
            Map(m => m.Isbn);

            References(x => x.GeneroLivro);
            References(x => x.AutorPrincipal);
            References(x => x.EditoraPublicacao);
        }
    }
}
