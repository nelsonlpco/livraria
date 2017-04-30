using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Infra.Repository;
using LivrariaHBSIS.Services;
using Microsoft.Practices.Unity;

namespace LivrariaHBSIS.Infra.IoC
{
    public class ContainerRegistration
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IAutorService, AutorService>();
            container.RegisterType<IEditoraService, EditoraService>();
            container.RegisterType<IGeneroService, GeneroService>();
            container.RegisterType<ILivroService, LivroService>();

            container.RegisterType<IAutorRepository, AutorRepository>();
            container.RegisterType<IEditoraRepository, EditoraRepository>();
            container.RegisterType<IGeneroRepository, GeneroRepository>();
            container.RegisterType<ILivroRepository, LivroRepository>();
        }
    }
}
