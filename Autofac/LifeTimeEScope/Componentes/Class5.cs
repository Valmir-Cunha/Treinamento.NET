using LifeTimeScope.Servicos;

namespace LifeTimeScope.Componentes
{
    public class Class5 : IService5
    {
        public Guid Id { get; set; }

        public Class5()
        {
            Console.WriteLine(this.GetType());
            Id = Guid.NewGuid();
        }

        public void Dados5()
        {
            Console.WriteLine(Id);
        }
    }
}
