using Autofac;

namespace InjecaoDependencia
{
    public static class RegistroPorLambdaExpression
    {
        private static ILifetimeScope _scope;
        private static ContainerBuilder _builder;

        static RegistroPorLambdaExpression()
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
