using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EcommerceAPI.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? NomeProduto { get; set; }

    public string DescricaoProduto { get; set; } = null!;

    public decimal Preco { get; set; }

    public int EstoqueDisponivel { get; set; }

    public string CategoriaProduto { get; set; } = null!;

    public string? ImagemProduto { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();
  
}
