using RegistroDependencias.Servicos;

    namespace RegistroDependencias.Componentes
{
    public class Cliente : IService1
    {
        public Guid _id;
        public string _nome;
        public string _cpf;

        public Cliente(string nome, Guid id)
        {
            _nome = nome;
            _id = id;
        }

        public Cliente(string nome, Guid id, string cpf)
        {
            _nome = nome;
            _id = id;
            _cpf = cpf;
        }

        public void Dados()
        {
            Console.WriteLine($"Id: {_id}");
            Console.WriteLine($"Nome: {_nome}");
            Console.WriteLine($"CPF: {_cpf}");
        }
    }
}
