using ResolvendoServicos.Servicos;

namespace ResolvendoServicos.Componentes
{
    public delegate IPessoa FactoryDelegate(string nome, Guid id, string cpf);
}
