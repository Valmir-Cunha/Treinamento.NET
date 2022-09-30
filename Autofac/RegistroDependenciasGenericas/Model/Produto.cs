namespace RegistroDependenciasGenericas.Model
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public Produto(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public void Dados()
        {
            Console.WriteLine(Id);
        }
    }
}
