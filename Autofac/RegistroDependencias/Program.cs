using Autofac;
using DependenciasCondicionais;
using RegistroDependencias.Componentes;
using RegistroDependencias.Servicos;
using System.Runtime.CompilerServices;

namespace InjecaoDependencia
{
    //Com Autofac
    public class Program
    {
        public static void Main()
        {
            RegistrosComParametros();
        }

        public static void ComponentesPorTipo()
        {
            RegistrosPorReflection.RegistrarComponentes();
            Console.WriteLine("Registro por tipo");
            using (var container = RegistrosPorReflection.CarregarContainer())
            {
                var classe = container.Resolve<Class1>();
                classe.Dados();
            }
        }

        public static void ComponentesPorInstancia()
        {
            RegistrosPorReflection.RegistrarComponentes();
            Console.WriteLine("Registro por instância");
            using (var container = RegistrosPorReflection.CarregarContainer())
            {
                var classe = container.Resolve<IService3>();
                classe.Dados3();
            }
        }

        public static void RegistrandoPorCondicional()
        {
            RegistroCondicional.RegistrarComponentes();
            Console.WriteLine("Registro por condicional");
            using (var container = RegistroCondicional.CarregarContainer())
            {
                try
                {
                    var classe2 = container.Resolve<Class2>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível fazer o registro da Classe2 pois a Classe 1 já registra o serviço IService");
                }
                var classe4 = container.Resolve<IService4>();
                classe4.Dados4();
            }
        }

        public static void RegistrosComParametros()
        {
            RegistroComParametros.RegistrarComponentes();
            using (var container = RegistroComParametros.CarregarContainer())
            {
                Console.WriteLine("Por nome");
                var cliente = container.Resolve<IService1>();
                cliente.Dados();
                Console.WriteLine("Por tipo");
                var classe5 = container.Resolve<IService4>();
                classe5.Dados4();
                Console.WriteLine("Por método resolved");
                var classe6 = container.Resolve<IService3>();
                classe6.Dados3();
                Console.WriteLine("Por expressão lambda");
                var classeLambda = container.Resolve<Class6>(new NamedParameter("id", Guid.NewGuid()), new NamedParameter("nome", "Teste Lambda"));
                classeLambda.Dados3();
            }
        }
    }
}