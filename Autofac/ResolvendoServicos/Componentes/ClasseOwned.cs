using Autofac.Features.OwnedInstances;
using ResolvendoServicos.Servicos;

namespace ResolvendoServicos.Componentes
{
    public class ClasseOwned : IServiceOwned
    {
        private Owned<IService2> _class2;

        public ClasseOwned(Owned<IService2> class2)
        {
            _class2 = class2;
        }

        public void Dados()
        {
            Console.WriteLine("Utilizando a dependencia");
            _class2.Value.Dados2();
            _class2.Dispose();
            Console.WriteLine("Descartando a dependencia");
        }
    }
}
