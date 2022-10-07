namespace FactoryMethod.Model
{
    public class Caminhao : Transporte
    {
        public Caminhao(string descricao, int fabricacao) : base(descricao, fabricacao)
        {
        }

        public override void Entregar(string pacote)
        {
            Console.WriteLine($"O pacote {pacote} será transportado por um caminhao modelo {_descricao}");
        }
    }
}
