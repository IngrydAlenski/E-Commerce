namespace EcommerceAPI.DTO
{
    public class CadastrarProtudoDTO
    {
        public string? NomeProduto { get; set; }

        public string DescricaoProduto { get; set; } = null!;

        public decimal Preco { get; set; }

        public int EstoqueDisponivel { get; set; }

        public string CategoriaProduto { get; set; } = null!;

        public string? ImagemProduto { get; set; }
    }
}
