using Autofac;
using FactoryMethod.Factories;
using FactoryMethod.Model;

namespace FactoryComAutofac
{
    public class Program
    {
        public static void Main()
        {
            Registros.RegistrarDependencias();
            TransporteFactory transporteFactory;
            Transporte transporte;
            string pacote = "N° 2893741892";
            Console.WriteLine("Digite o código do tipo de transporte que deseja utilizar no envio:");
            Console.WriteLine("1 - Caminhão | 2 - Avião");
            string codigo = Console.ReadLine();
            using (var containerFilho = Registros.CarregarContainer())
            {
                switch (codigo)
                {
                    case "1":
                        transporteFactory = containerFilho.Resolve<CaminhaoFactory>();
                        transporte = transporteFactory.CriarTransporte("Modelo X", 2015);
                        transporte.Entregar(pacote);
                        transporteFactory._serviceSimulado.FazAlgo();
                        break;
                    case "2":
                        transporteFactory = containerFilho.Resolve<AviaoFactory>();
                        transporte = transporteFactory.CriarTransporte("Modelo Y", 2016);
                        transporte.Entregar(pacote);
                        transporteFactory._serviceSimulado.FazAlgo();
                        break;
                }
                
            }
        }
    }
}