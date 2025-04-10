using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IProdutoRepository
    {
        //   R - READ LEITURA
        List<Produto> ListarTodos();

        //RECEBE INDENTIFICADOR, E RETORNA O PRODUTO CORRESPONDENTE
        Produto BuscarPorId(int id);

        //C - CREATE CADASTRO
        void Cadastrar(Produto produto);

        // U - UPDATE ATUALIZAÇÃO
        //RECEBE UM INDENTIFICADOR PARA ENCONTAR O PRODUTO, RECEBE O PRODUTO, E RECEBE O PRODUTO NOVO PARA SUBSTIRUIR O ANTIGO
        void Atualizar(int id, Produto produto);
    // D - DELETE DELETAR 
    //RECEBE O INDENTIFICADOR DE QUEM QUER EXCLUIR 
    void Deletar (int id);

    }
}
