using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Login
{
    public class TokenGetDto
    {
        [JsonPropertyName("Token")]
        public string Token { get; set; }

        [JsonPropertyName("Login")]
        public string Login { get; set; }
    }
}
