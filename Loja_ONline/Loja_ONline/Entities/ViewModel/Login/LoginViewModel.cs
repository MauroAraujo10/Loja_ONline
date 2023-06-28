using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Login
{
    public class LoginViewModel
    {
        [JsonPropertyName("Login")]
        public string Login { get; set; }
        
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
