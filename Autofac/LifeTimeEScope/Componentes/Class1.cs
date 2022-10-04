using LifeTimeScope.Servicos;

namespace LifeTimeScope.Componentes
{
    public class Class1 : IService1, IService
    {
        public Guid Id { get; set; }

        public Class1()
        {
            Console.WriteLine(this.GetType());
            Console.WriteLine("Construtor 1");
            Id = Guid.NewGuid();
        }

        public Class1(IService2 classe2)
        {
            Console.WriteLine(this.GetType());
            Console.WriteLine("Construtor 2");
            Id = Guid.NewGuid();
        }

        public Class1(IService2 classe2, IService3 classe3)
        {
            Console.WriteLine(this.GetType());
            Console.WriteLine("Construtor 3");
            Id = Guid.NewGuid();
        }
        public void Dados()
        {
            Console.WriteLine(Id);
        }
    }
}
