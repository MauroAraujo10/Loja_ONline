using Loja_ONline.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_ONline.Entities
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        public string IdProduto { get; set; }

        [ForeignKey("IdVendedor")]
        public string IdVendedor { get; set; }

        public string Imagem { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public DateTime DataCadastro { get; set; }

        public int QuantidadeEstoque { get; set; }

        public string Descricao { get; set; }

        public StatusProduct Status { get; set; }

        public virtual Vendedores Vendedores { get; set; }
    }
}
