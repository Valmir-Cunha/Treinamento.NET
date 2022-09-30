using RegistroDependenciasGenericas.Interfaces;

namespace RegistroDependenciasGenericas
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ContextoDb _contexto;
        protected readonly BancoDadosEmMemoria bancoDadosEmMemoria;

        public Repository(BancoDadosEmMemoria bancoDadosEmMemoria)
        {
            _contexto = bancoDadosEmMemoria.PegarContexto();
        }

        public IQueryable<T> ObterTodos()
        {
            return _contexto.Set<T>();
        }
    }
}
