using Autofac;
using Autofac.Builder;
using Autofac.Core;
using ResolvendoServicos.Componentes;
using ResolvendoServicos.Servicos;

namespace ResolvendoServicos
{
    public static class Registros
    {
        private static ILifetimeScope _scope;
        private static ContainerBuilder _builder;

        static Registros()
        {
            _builder ??= new ContainerBuilder();
        }

        public static ILifetimeScope CarregarContainer()
        {
            return _scope.BeginLifetimeScope();
        }

        public static void RegistrarComponentes()
        {
            _builder.RegisterType<ClasseLazy>().As<IServiceLazy>();
            _builder.RegisterType<Class2>().As<IService2>();
            _builder.RegisterType<ClasseOwned>().As<IServiceOwned>();
            _builder.RegisterType<ClasseFunc>().As<IServiceFunc>();
            _builder.RegisterType<ClasseParametrizada>().AsSelf();
            
            _builder.RegisterType<Cliente>().As<IPessoa>();
            _builder.Register((c, p) => new Class6(p.Named<Guid>("id"), p.Named<string>("nome")))
                .As<IService3>();

            _builder.RegisterGeneratedFactory<FactoryDelegate>(new TypedService(typeof(IPessoa)));

            _scope = _builder.Build();
        }
    }
}
