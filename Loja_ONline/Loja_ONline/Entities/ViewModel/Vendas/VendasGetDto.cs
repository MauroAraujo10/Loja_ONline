using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Vendas
{
    public class VendasGetDto
    {
        [JsonPropertyName("IdVenda")]
        public string IdVenda { get; set; }
        
        [JsonPropertyName("IdProduto")]
        public string IdProduto { get; set; }

        [JsonPropertyName("DataVenda")]
        public DateTime DataVenda { get; set; }
        
        [JsonPropertyName("NomeVendedor")]
        public string NomeVendedor { get; set; }

        [JsonPropertyName("QuantidadeComprada")]
        public int QuantidadeComprada { get; set; }

        [JsonPropertyName("ValorPago")]
        public decimal ValorPago { get; set; }
    }
}
