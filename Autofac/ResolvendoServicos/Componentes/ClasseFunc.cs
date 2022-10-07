using ResolvendoServicos.Servicos;

namespace ResolvendoServicos.Componentes
{
    public class ClasseFunc : IServiceFunc
    {
        private Func<IService2> _class2;
        public ClasseFunc(Func<IService2> class2)
        {
            _class2=class2;
            Console.WriteLine("Sainda do construtor");
        }

        public void Dados()
        {
            Console.WriteLine("Instanciando agora");
            var classe2 = _class2();
            classe2.Dados2();
        }
    }
}
