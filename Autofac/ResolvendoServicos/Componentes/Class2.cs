using ResolvendoServicos.Servicos;

namespace ResolvendoServicos.Componentes
{
    public class Class2 : IService2, IDisposable
    {
        public Guid Id { get; set; }

        public Class2()
        {
            Console.WriteLine(this.GetType());
            Id = Guid.NewGuid();
        }
        public void Dados2()
        {
            Console.WriteLine(Id);
        }

        public void Dispose()
        {
            
        }
    }
}
