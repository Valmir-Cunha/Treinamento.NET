using LifeTimeScope.Servicos;

namespace LifeTimeScope.Componentes
{
    public class Class2 : IService2
    {
        public Guid Id { get; set; }

        public Class2()
        {
            Id = Guid.NewGuid();
        }
        public void Dados2()
        {
            Console.WriteLine(Id);
        }
    }
}
