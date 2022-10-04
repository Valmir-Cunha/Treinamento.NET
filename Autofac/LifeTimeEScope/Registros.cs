using Autofac;
using LifeTimeScope.Componentes;
using LifeTimeScope.Servicos;

namespace LifeTimeEScope
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
            _builder.RegisterType<Class1>().As<IService1>().InstancePerDependency();
            _builder.RegisterType<Class2>().As<IService2>().SingleInstance();
            _builder.RegisterType<Class3>().As<IService3>().InstancePerLifetimeScope();
            _builder.RegisterType<Class4>().As<IService4>().InstancePerMatchingLifetimeScope();
            _builder.RegisterType<Class5>().As<IService5>().InstancePerRequest();
            //_builder.RegisterType<Class6>().As<IService6>().InstancePerOwned<>();

            _scope = _builder.Build();
        }
    }

}
