using System.Text.Json.Serialization;

namespace Loja_ONline.Utils
{
    public class ExceptionDto
    {
        [JsonPropertyName("Mensagem")]
        public string Mensagem{ get; set; }

        [JsonPropertyName("Excecao")]
        public string Excecao { get; set; }
    }
}
