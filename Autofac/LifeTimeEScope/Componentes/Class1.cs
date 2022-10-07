using LifeTimeScope.Servicos;

namespace LifeTimeScope.Componentes
{
    public class Class1 : IService1
    {
        public Guid Id { get; set; }

        public Class1()
        {
            Id = Guid.NewGuid();
        }
        public void Dados()
        {
            Console.WriteLine(Id);
        }
    }
}
