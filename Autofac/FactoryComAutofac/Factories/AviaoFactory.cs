using FactoryComAutofac;
using FactoryMethod.Model;

namespace FactoryMethod.Factories
{
    public class AviaoFactory : TransporteFactory
    {
        public AviaoFactory(IServiceSimulado serviceSimulado) : base(serviceSimulado)
        {
        }

        public override Transporte CriarTransporte(string descricao, int anoFabricacao)
        {
            return new Aviao(descricao, anoFabricacao);
        }
    }
}
