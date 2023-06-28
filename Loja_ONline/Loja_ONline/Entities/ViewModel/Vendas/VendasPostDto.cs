using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Vendas
{
    public class VendasPostDto
    {
        [JsonPropertyName("IdProduto")]
        public string IdProduto { get; set; }
        
        [JsonPropertyName("QuantidadeComprada")]
        public int QuantidadeComprada { get; set; }
        
        [JsonPropertyName("ValorPago")]
        public decimal ValorPago { get; set; }
    }
}
