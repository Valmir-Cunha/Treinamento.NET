using RegistroDependenciasGenericas.Interfaces;
using RegistroDependenciasGenericas.Model;

namespace RegistroDependenciasGenericas
{
    public class PaginaBusca
    {
        private IRepository<Produto> _produtos;
        private IRepository<Cliente> _clientes;
        public PaginaBusca(IRepository<Produto> produtos, IRepository<Cliente> clientes)
        {
            _produtos = produtos;
            _clientes = clientes;
        }
        public void ExibirProdutos()
        {
            var produtos = _produtos.ObterTodos().ToList();
            foreach (var item in produtos)
            {
                Console.WriteLine($"Id: {item.Id}\nDescrição: {item.Descricao}");
            }
        }
        public void ExibirClientes()
        {
            var clientes = _clientes.ObterTodos();
            foreach (var item in clientes)
            {
                Console.WriteLine($"Id: {item.Id}\nNome: {item.Nome}");
            }
        }
    }
}
