using FluentNHibernate.Mapping;
using LivrariaHBSIS.domain;

namespace LivrariaHBSIS.Infra.Mapping
{
    public class GeneroMap : ClassMap<Genero>
    {
        public GeneroMap()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Descricao);

            HasMany(x => x.Livros).Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
