using ResolvendoServicos.Servicos;

namespace ResolvendoServicos.Componentes
{
    public class ClasseParametrizada
    {
        //Como o func utiliza o TypedParameter, o construtor não pode ter tipos iguais, caso seja necessário haver tipos iguais, crie uma fabrica delegada
        private Func<string, Guid, IPessoa> _cliente;

        

        
        public ClasseParametrizada(Func<string, Guid, IPessoa> cliente)
        {
            _cliente = cliente;
        }

        public void CriarCliente()
        {
            Console.WriteLine("Instanciando agora");
            var classe = _cliente("Vinicius", Guid.NewGuid());
            Cliente cliente = (Cliente) classe;
            Console.WriteLine($"Id cliente:{cliente._id} \nNome cliente: {cliente._nome}");
        }
    }
}
