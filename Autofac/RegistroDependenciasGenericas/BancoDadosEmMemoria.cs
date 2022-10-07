using Microsoft.EntityFrameworkCore;
using RegistroDependenciasGenericas.Model;

namespace RegistroDependenciasGenericas
{
    public class BancoDadosEmMemoria : DbContext
    {
        private readonly ContextoDb _contexto;
        public BancoDadosEmMemoria()
        {
            _contexto = new ContextoDb(
                new DbContextOptionsBuilder<ContextoDb>()
                .UseInMemoryDatabase("Db")
                .Options);
            InserirDados();
        }
        public ContextoDb PegarContexto()
        {
            return _contexto;
        }
        public void InserirDados()
        {
            InserirClientes();
            InserirProdutos();
        }
        public void InserirClientes()
        {
            _contexto.Cliente.Add(
                new Cliente("Fulano")
            );
            _contexto.Cliente.Add(
                new Cliente("Beltrano")
            );
            _contexto.SaveChanges();
        }
        public void InserirProdutos()
        {
            _contexto.Produto.Add(
                new Produto("Mobil")
            );
            _contexto.Produto.Add(
                new Produto("Lubrax")
            );
            _contexto.SaveChanges();
        }
    }
}
