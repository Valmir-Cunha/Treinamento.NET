using Autofac;
using Autofac.Core;
using RegistroDependencias.Componentes;
using RegistroDependencias.Servicos;

namespace DependenciasCondicionais
{
    public static class RegistroComParametros
    {
        private static ILifetimeScope _scope;
        private static ContainerBuilder _builder;

        static RegistroComParametros()
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

            _scope = _builder.Build();
        }
    }
}
