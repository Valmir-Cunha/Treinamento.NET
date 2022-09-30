using Autofac;

namespace RegistroDependenciasGenericas
{
    public class Program
    {
        public static void Main()
        {
            //Não retorna nada
            DI.RegistraDependencias();
            using (var container = DI.CorregarContainer())
            {
                var busca = container.Resolve<PaginaBusca>();
                busca.ExibirProdutos();
                busca.ExibirClientes();
            }
        }
    }
}