﻿using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IPedido
    {
        List<Pedido> ListarTodos();
        Pedido BuscarPorId(int id);

        void Cadastrar(Pedido pedido);

        void Atualizar(int id, Pedido pedido);

        void Deletar(int id);
    }
}
