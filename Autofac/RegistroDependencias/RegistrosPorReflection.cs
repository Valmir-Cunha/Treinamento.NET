using Autofac;
using RegistroDependencias.Componentes;
using RegistroDependencias.Servicos;

namespace InjecaoDependencia
{
    public static class RegistrosPorReflection
    {
        private static ILifetimeScope _scope;
        private static ContainerBuilder _builder;

        static RegistrosPorReflection()
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
            //Registros por tipo

            //Registrando somente o tipo
            _builder.RegisterType<Class1>(); // Maneira 1

            //Definindo o construtor:
            _builder.RegisterType<Class1>().UsingConstructor(typeof(IService2));

            //Registrando o componente "Class2" ao serviço "IService2", ou seja, ao instanciar o tipo será "IService2"
            _builder.RegisterType<Class2>().As<IService2>();

            //Registro por instâncias
            IService3 classe3 = new Class3();
            _builder.RegisterInstance(classe3).As<IService3>();

            //Construindo container
            _scope = _builder.Build();
        }
    }
}
