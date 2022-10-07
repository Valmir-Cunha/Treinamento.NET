namespace FactoryComAutofac
{
    public class ServicoSimulado : IServiceSimulado
    {
        public void FazAlgo()
        {
            Console.WriteLine("Fazendo algo.... blá blá");
            Console.WriteLine("Como podemos observar, a dependencia foi resolvida na fabrica");
        }
    }
}
