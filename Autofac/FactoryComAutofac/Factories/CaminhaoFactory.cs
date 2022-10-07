using FactoryComAutofac;
using FactoryMethod.Model;

namespace FactoryMethod.Factories
{
    public class CaminhaoFactory : TransporteFactory
    {
        public CaminhaoFactory(IServiceSimulado serviceSimulado) : base(serviceSimulado)
        {
        }

        public override Transporte CriarTransporte(string descricao, int anoFabricacao)
        {
            return new Caminhao(descricao, anoFabricacao);
        }
    }
}
