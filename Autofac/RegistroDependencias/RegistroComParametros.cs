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
            // Relacionando o parâmetro por nome:
            _builder.RegisterType<Cliente>()
                    .As<IService1>()
                    .WithParameter("nome", "Fulano")
                    .WithParameter("cpf", "11122233344")
                    .WithParameter("id", Guid.NewGuid());

            //Relacionando por tipo
            //*Importante*: Caso exista parâmetros de tipos iguais, uma excessão será lançada, já que o autorfac não sabe qual utilizar
            _builder.RegisterType<Class5>()
                .As<IService4>()
                .WithParameter(new TypedParameter(typeof(string), "Teste"))
                .WithParameter(new TypedParameter(typeof(Guid), Guid.NewGuid()));



            // Relacionando o parâmetro por resolução:
            _builder.RegisterType<Class6>()
                   .As<IService3>()
                   .WithParameter(
                     new ResolvedParameter(
                       (p, ctx) => p.ParameterType == typeof(string) && p.Name == "nome",
                       (p, ctx) => "Teste 2"))
                   .WithParameter(
                     new ResolvedParameter(
                       (p, ctx) => p.ParameterType == typeof(Guid) && p.Name == "id",
                       (p, ctx) => Guid.NewGuid()));



            //COM LAMBDA EXPRESSION
            _builder.Register((c,p) => new Class6(p.Named<Guid>("id"),p.Named<string>("nome")));
            _scope = _builder.Build();
        }
    }
}
