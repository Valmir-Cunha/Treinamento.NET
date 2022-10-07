using RegistroDependencias.Servicos;

namespace RegistroDependencias.Componentes
{
    public class Class6 : IService3
    {
        public Guid _id;
        public string _nome;

        public Class6(Guid id, string nome)
        {
            _nome = nome;
            _id = id;
        }

        public void Dados3()
        {
            Console.WriteLine($"Id: {_id}");
            Console.WriteLine($"Nome: {_nome}");
        }
    }
}
