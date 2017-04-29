using FluentNHibernate.Mapping;
using LivrariaHBSIS.domain;

namespace LivrariaHBSIS.Infra.Map
{
    public class AutorMap : ClassMap<Autor>
    {
        public AutorMap()
        {
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.Nome);

            HasMany(x => x.Livros).Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
