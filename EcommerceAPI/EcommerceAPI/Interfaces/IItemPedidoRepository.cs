﻿using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IItemPedidoRepository
    {
        List<ItemPedido> ListarTodos();
       ItemPedido BuscarPorId(int id);

        void Cadastrar(ItemPedido itemPedido);

        void Atualizar(int id, ItemPedido  itempedido);

        void Deletar(int id);
    }
}
