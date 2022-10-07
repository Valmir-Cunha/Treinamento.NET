using Autofac;
using RegistroDependenciasGenericas.Interfaces;

namespace RegistroDependenciasGenericas
{
    public static class DI
    {
        private static ILifetimeScope _scope;
        private static ContainerBuilder _builder;

        static DI()
        {
            _builder ??= new ContainerBuilder();
        }

        public static ILifetimeScope CorregarContainer()
        {
            return _scope.BeginLifetimeScope();
        }

        public static void RegistraDependencias()
        {
            _builder.RegisterType<BancoDadosEmMemoria>().AsSelf().InstancePerLifetimeScope();
            _builder.RegisterType<PaginaBusca>().AsSelf().InstancePerDependency();

            //Registro generico
            _builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();          

            _scope = _builder.Build();
        }


    }
}
