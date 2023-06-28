using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja_ONline.Entities
{
    [Table("Vendas")]
    public class Vendas
    {
        [Key]
        [JsonPropertyName("IdVenda")]
        public string IdVenda { get; set; }

        [JsonPropertyName("IdProduto")]
        public string IdProduto { get; set; }
        
        [JsonPropertyName("DataVenda")]
        public DateTime DataVenda{ get; set; }
        
        [JsonPropertyName("QuantidadeComprada")]
        public int QuantidadeComprada { get; set; }
        
        [JsonPropertyName("ValorPago")]
        public decimal ValorPago { get; set; }

        public virtual Produtos Produtos{ get; set; }
    }
}
