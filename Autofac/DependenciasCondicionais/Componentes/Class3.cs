using RegistroDependencias.Servicos;

namespace RegistroDependencias.Componentes
{
    public class Class3 : IService3
    {
        public Guid Id { get; set; }

        public Class3()
        {
            Console.WriteLine(this.GetType());
            Id = Guid.NewGuid();
        }

        public void Dados3()
        {
            Console.WriteLine(Id);
        }
    }
}
