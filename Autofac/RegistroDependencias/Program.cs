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
            ComponentesPorInstancia();
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
    }
}