﻿using Loja_ONline.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja_ONline.Entities
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [JsonPropertyName("IdProduto")]
        public string IdProduto { get; set; }

        [ForeignKey("IdUsuario")]
        [JsonPropertyName("IdUsuario")]
        public string IdUsuario { get; set; }

        [JsonPropertyName("Imagem")]
        public string Imagem { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Preco")]
        public decimal Preco { get; set; }

        [JsonPropertyName("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonPropertyName("QuantidadeEstoque")]
        public int QuantidadeEstoque { get; set; }

        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("Status")]
        public StatusProduct Status { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
