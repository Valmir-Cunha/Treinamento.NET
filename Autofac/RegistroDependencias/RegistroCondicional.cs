using Autofac;
using Autofac.Core;
using RegistroDependencias.Componentes;
using RegistroDependencias.Servicos;
using System.ComponentModel;

namespace DependenciasCondicionais
{
    public static class RegistroCondicional
    {
        private static ILifetimeScope _scope;
        private static ContainerBuilder _builder;

        static RegistroCondicional()
        {
            _builder ??= new ContainerBuilder();
        }

        //Iniciando conteiner filho
        public static ILifetimeScope CarregarContainer()
        {
            return _scope.BeginLifetimeScope();
        }

        public static void RegistrarComponentes()
        {
            _builder.RegisterType<Class1>().As<IService>();

            //Irá registrar classe2 somente se não tiver nenhum outro registro de IService
            _builder.RegisterType<Class2>().As<IService>().IfNotRegistered(typeof(IService));

            _builder.RegisterType<Class3>().As<IService3>().InstancePerDependency();
            
            //Irá registrar classe2 somente se tiver um registro de IService
            _builder.RegisterType<Class4>().As<IService4>()
                .OnlyIf(reg => reg.IsRegistered(new TypedService(typeof(IService))) && reg.IsRegistered(new TypedService(typeof(IService3))));

            _scope = _builder.Build();
        }

    }
}
