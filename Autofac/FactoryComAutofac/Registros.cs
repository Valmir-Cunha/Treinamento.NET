using Autofac;
using Autofac.Core.Lifetime;
using FactoryMethod.Factories;

namespace FactoryComAutofac
{
    static class Registros
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

        public static void RegistrarDependencias()
        {
            _builder.RegisterType<ServicoSimulado>().As<IServiceSimulado>();
            _builder.RegisterType<AviaoFactory>().AsSelf();
            _builder.RegisterType<CaminhaoFactory>().AsSelf();
            _scope = _builder.Build();
        }



    }
}
