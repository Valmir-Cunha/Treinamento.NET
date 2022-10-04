using LifeTimeScope.Servicos;

namespace LifeTimeScope.Componentes
{
    public class Class2 : IService2, IService
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
    }
}
