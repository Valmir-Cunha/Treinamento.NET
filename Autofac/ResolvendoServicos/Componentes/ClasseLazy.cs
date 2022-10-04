using ResolvendoServicos.Servicos;

namespace ResolvendoServicos.Componentes
{
    public class ClasseLazy : IServiceLazy
    {
        public Lazy<IService2> _class2;

        public ClasseLazy(Lazy<IService2> class2)
        {
            _class2 = class2;
        }
        public void Dados()
        {
            Console.WriteLine("Primeiro uso da Class2");
            _class2.Value.Dados2();
        }
    }
}
