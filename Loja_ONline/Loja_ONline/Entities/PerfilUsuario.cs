using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja_ONline.Entities
{
    [Table("PerfilUsuario")]
    public class PerfilUsuario
    {
        [Key]
        [JsonPropertyName("IdPerfil")]
        public string IdPerfil { get; set; }

        [Required]
        [JsonPropertyName("Perfil")]
        public string Perfil { get; set; }
    }
}
