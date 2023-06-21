using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_ONline.Entities
{
    [Table("Vendedores")]
    public class Vendedores
    {
        [Key]
        public string IdVendedor { get; set; }

        [ForeignKey("IdUsuario")]
        public string IdUsuario { get; set; }
        public int QuantidadeVendas { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
