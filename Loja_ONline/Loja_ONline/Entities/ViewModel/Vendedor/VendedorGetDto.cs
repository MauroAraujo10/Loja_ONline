using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Vendedor
{
    public class VendedorGetDto
    {
        [JsonPropertyName("IdVendedor")]
        public Guid IdVendedor{ get; set; }

        [JsonPropertyName("IdUsuario")]
        public Guid IdUsuario{ get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("QuantidadeVendas")]
        public int QuantidadeVendas { get; set; }

        [JsonPropertyName("DataNascimento")]
        public DateTime DataNascimento{ get; set; }

        [JsonPropertyName("Sexo")]
        public string Sexo { get; set; }

        [JsonPropertyName("Login")]
        public string Login { get; set; }
    }
}
