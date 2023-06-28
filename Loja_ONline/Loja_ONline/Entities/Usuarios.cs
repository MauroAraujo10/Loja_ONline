using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja_ONline.Entities
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [JsonPropertyName("IdUsuario")]
        public string IdUsuario { get; set; }

        [ForeignKey("IdPerfil")]
        [JsonPropertyName("IdPerfil")]
        public string IdPerfil { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonPropertyName("CPF")]
        public string CPF{ get; set; }

        [JsonPropertyName("Sexo")]
        public char Sexo { get; set; }

        [JsonPropertyName("Login")]
        public string Login { get; set; }

        [JsonPropertyName("Senha")]
        public string Senha { get; set; }

        public virtual PerfilUsuario PerfilUsuario { get; set; }
    }
}
