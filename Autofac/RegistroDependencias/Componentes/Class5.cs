using RegistroDependencias.Servicos;

namespace RegistroDependencias.Componentes
{
    public class Class5 : IService4
    {
        public Guid _id;
        public string _nome;

        public Class5(Guid id, string nome)
        {
            _nome = nome;
            _id = id;
        }

        public void Dados4()
        {
            Console.WriteLine($"Id: {_id}");
            Console.WriteLine($"Nome: {_nome}");
        }
    }
}
