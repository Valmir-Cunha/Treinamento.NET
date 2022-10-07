using ResolvendoServicos.Servicos;

    namespace ResolvendoServicos.Componentes
{
    public class Cliente2 : IPessoa
    {
        public Guid _id;
        public string _nome;
        public string _cpf;

        public Cliente2(string nome, Guid id)
        {
            _nome = nome;
            _id = id;
        }

        public Cliente2(string nome, Guid id, string cpf)
        {
            _nome = nome;
            _id = id;
            _cpf = cpf;
        }
        
    }
}
