using FactoryComAutofac;
using FactoryMethod.Model;

namespace FactoryMethod.Factories
{
    public abstract class TransporteFactory
    {
        public IServiceSimulado _serviceSimulado;

        public TransporteFactory(IServiceSimulado serviceSimulado)
        {
            _serviceSimulado=serviceSimulado;
        }

        public abstract Transporte CriarTransporte(string descricao, int anoFabricacao);
    }
}
