using LifeTimeScope.Servicos;

namespace LifeTimeScope.Componentes
{
    public class Class4 : IService4
    {
        public Guid Id { get; set; }

        public Class4()
        {
            Console.WriteLine(this.GetType());
            Id = Guid.NewGuid();
        }

        public void Dados4()
        {
            Console.WriteLine(Id);
        }
    }
}
