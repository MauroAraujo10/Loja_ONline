using Loja_ONline.Utils.Enums;
using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Produtos
{
    public class ProductsViewModel
    {
        [JsonPropertyName("IdProduto")]
        public Guid IdProduto { get; set; }

        [JsonPropertyName("Imagem")]
        public string Imagem { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("NomeVendedor")]
        public string NomeVendedor { get; set; }

        [JsonPropertyName("Preco")]
        public decimal Preco { get; set; }

        [JsonPropertyName("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonPropertyName("QuantidadeEstoque")]
        public int QuantidadeEstoque { get; set; }

        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("Status")]
        public StatusProduct Status { get; set; }
    }
}
