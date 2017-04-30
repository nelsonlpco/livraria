using LivrariaHBSIS.domain.Interfaces;
using LivrariaHBSIS.domain.Interfaces.Services;
using LivrariaHBSIS.Infra.Repository;
using LivrariaHBSIS.Services;
using Microsoft.Practices.Unity;

namespace LivrariaHBSIS.ServiceLocator
{
    public class BuilderUnityContainer
    {

        public IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType();            
            container.RegisterType<IAutorService, AutorService>();
            container.RegisterType<IEditoraService, EditoraService>();
            container.RegisterType<IGeneroService, GeneroService>();
            container.RegisterType<ILivroService, LivroService>();

            container.RegisterType<IAutorRepository, AutorRepository>();
            container.RegisterType<IEditoraRepository, EditoraRepository>();
            container.RegisterType<IGeneroRepository, GeneroRepository>();
            container.RegisterType<ILivroRepository, LivroRepository>();


            return container;
        }
    }
}
