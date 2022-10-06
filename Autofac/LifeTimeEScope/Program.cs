using Autofac;
using LifeTimeScope.Servicos;

namespace LifeTimeScope
{
    public class Program
    {
        public static void Main()
        {
            //InstanciaPorDependencia();
            //IntanciaUnica();
            //IntanciaPorTempoDeVida();
            IntanciaPorTempoDeVidaDeEscopoCorrespondente();
            //InstanciaPorSolicitacao();
        }

        public static void InstanciaPorDependencia()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                for(int i = 0; i < 3; i++)
                {
                    var classe = containerFilho.Resolve<IService1>();
                    Console.Write($"Instância {i}: \nId:");
                    classe.Dados();
                }
            }
        }

        public static void IntanciaUnica()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                for (int i = 0; i < 3; i++)
                {
                    var classe = containerFilho.Resolve<IService2>();
                    Console.Write($"Pedido {i} de instância: \nId:");
                    classe.Dados2();
                }
                Console.Write($"Todo possuem o mesmo id, ou seja, somente uma instância foi criada");
            }
        }

        public static void IntanciaPorTempoDeVida()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                Console.WriteLine($"1° Escopo");
                for (int i = 0; i < 3; i++)
                {
                    var classe = containerFilho.Resolve<IService3>();
                    Console.Write($"Pedido {i} de instância: \nId:");
                    classe.Dados3();
                }
                Console.WriteLine($"Todo possuem o mesmo id, ou seja, somente uma instância foi criada no escopo");
                Console.WriteLine($"==================================================================");
            }

            using (var containerFilho2 = Registros.CarregarContainer())
            {
                Console.WriteLine($"2° Escopo");
                for (int i = 0; i < 3; i++)
                {
                    var classe = containerFilho2.Resolve<IService3>();
                    Console.Write($"Pedido {i} de instância: \nId:");
                    classe.Dados3();
                }
                Console.WriteLine($"Todo possuem o mesmo id, ou seja, somente uma instância foi criada no escopo");
            }
        }

        public static void IntanciaPorTempoDeVidaDeEscopoCorrespondente()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainerNomeado("escopoTeste"))
            {
                for (int i = 0; i < 3; i++)
                {
                    var classe = containerFilho.Resolve<IService4>();
                    classe.Dados4();
                    using (var containerFilho2 = containerFilho.BeginLifetimeScope())
                    {
                        var classe2 = containerFilho2.Resolve<IService4>();
                        classe2.Dados4();
                    }
                }
            }
        }

        //Erro
        public static void InstanciaPorSolicitacao()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                for (int i = 0; i < 3; i++)
                {
                    var classe = containerFilho.Resolve<IService5>();
                    Console.Write($"Instância {i}: \nId:");
                    classe.Dados5();
                }
            }
        }



    }
}