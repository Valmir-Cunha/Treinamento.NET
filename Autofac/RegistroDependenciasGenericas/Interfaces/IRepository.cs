namespace RegistroDependenciasGenericas.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObterTodos();
    }
}
