using Loja_ONline.Utils.Enums;

namespace Loja_ONline.Entities
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Descricao { get; set; }
        public StatusProduct Status { get; set; }
    }
}
