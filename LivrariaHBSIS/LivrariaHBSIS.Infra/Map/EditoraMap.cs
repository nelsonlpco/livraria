using FluentNHibernate.Mapping;
using LivrariaHBSIS.domain;

namespace LivrariaHBSIS.Infra.Map
{
    class EditoraMap : ClassMap<Editora>
    {
        public EditoraMap()
        {
            Id(e => e.Id).GeneratedBy.Identity();
            Map(e => e.Nome);

            HasMany(x => x.Livros).Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
