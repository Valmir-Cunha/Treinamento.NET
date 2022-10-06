using Autofac;
using ResolvendoServicos.Servicos;
using ResolvendoServicos.Componentes;

namespace ResolvendoServicos.Program
{
    public class Program
    {
        public static void Main()
        {
            ResolvendoServicosComParamentros();
            //ResolvendoServicosComDependenciasPreguicosa();
            //ResolvendoServicosComLifeTimeControlado();
            //ResolvendoServicosComInstanciacaoDinanmica();
            //ResolvendoServicosComParametros();
            //ResolvendoServicosComTiposDeParametrosDuplicados();
        }


        public static void ResolvendoServicosComParamentros()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                var classe = containerFilho.Resolve<IPessoa>(new NamedParameter("nome", "Vinicius"),new TypedParameter(typeof(Guid), Guid.NewGuid()));
                Cliente cliente = (Cliente) classe;
                Console.WriteLine("Instancia criada passando parâmtros no resolve:");
                Console.WriteLine($"Id cliente:{cliente._id} \nNome cliente: {cliente._nome}");

                Console.WriteLine("Instancia criada passando parâmtros no resolve com expressão lambda:");
                var classe6 = containerFilho.Resolve<IService3>(new NamedParameter("id", Guid.NewGuid()), new NamedParameter("nome", "Fulano"));
                classe6.Dados3();
            }
        }

        //Depedencias preguiçosa que não é instanciada até seu primeiro uso.
        public static void ResolvendoServicosComDependenciasPreguicosa()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                var classe = containerFilho.Resolve<IServiceLazy>();
                classe.Dados();
            }
        }

        public static void ResolvendoServicosComLifeTimeControlado()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                var classe = containerFilho.Resolve<IServiceOwned>();
                classe.Dados();
            }
        }

        public static void ResolvendoServicosComInstanciacaoDinanmica()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                var classe = containerFilho.Resolve<IServiceFunc>();
                classe.Dados();
            }
        }

        public static void ResolvendoServicosComParametros()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                var classe = containerFilho.Resolve<ClasseParametrizada>();
                classe.CriarCliente();
            }
        }

        public static void ResolvendoServicosComTiposDeParametrosDuplicados()
        {
            Registros.RegistrarComponentes();
            using (var containerFilho = Registros.CarregarContainer())
            {
                var factory = containerFilho.Resolve<FactoryDelegate>();
                var classe = factory("Vinicius", Guid.NewGuid(), "00011122233");
                Cliente cliente = (Cliente) classe;
                Console.WriteLine($"Id cliente: {cliente._id} \nNome cliente: {cliente._nome} \nCPF cliente: {cliente._nome}");
            }
        }

    }
}