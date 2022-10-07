namespace FactoryMethod.Model
{
    public abstract class Transporte
    {
        protected string _descricao;
        protected int _anoFabricacao;

        public Transporte(string descricao, int fabricacao)
        {
            _descricao = descricao;
            _anoFabricacao = fabricacao;
        }

        public abstract void Entregar(string pacote);
    }
}
