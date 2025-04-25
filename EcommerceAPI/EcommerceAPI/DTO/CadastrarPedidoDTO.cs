namespace EcommerceAPI.DTO
{
    public class CadastrarPedidoDTO
    {
        public DateOnly DataPedido { get; set; }

        public string StatusPedido { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        //Produtos comprados
        //list int para receber apenas o ID do produto, ao inves de receber todas as informacoes
        //Eu recebo os dados do pedido
        public List<int> Produtos { get; set; } 
    }
}
