using Loja_ONline.Utils.Enums;
using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Produtos
{
    public class ProdutosPostDto
    {
        [JsonPropertyName("Login")]
        public string Login { get; set; }
        
        [JsonPropertyName("Imagem")]
        public string Imagem { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Preco")]
        public decimal Preco { get; set; }

        [JsonPropertyName("QuantidadeEstoque")]
        public int QuantidadeEstoque { get; set; }

        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("Status")]
        public StatusProduct Status { get; set; }
    }
}
