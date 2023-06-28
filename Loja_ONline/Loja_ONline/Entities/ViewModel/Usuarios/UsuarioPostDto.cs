using System.Text.Json.Serialization;

namespace Loja_ONline.Entities.ViewModel.Usuarios
{
    public class UsuarioPostDto
    {
        [JsonPropertyName("Nome")]
        public string Nome{ get; set; }

        [JsonPropertyName("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonPropertyName("CPF")]
        public string CPF { get; set; }
        
        [JsonPropertyName("Sexo")]
        public char Sexo { get; set; }

        [JsonPropertyName("Login")]
        public string Login { get; set; }

        [JsonPropertyName("Senha")]
        public string Senha { get; set; }
    }
}