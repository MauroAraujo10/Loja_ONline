using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_ONline.Entities
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
