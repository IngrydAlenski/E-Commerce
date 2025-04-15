using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {

        private Interfaces.IItemPedidoRepository ItempedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {
            ItempedidoRepository = itemPedidoRepository;
        }
    }
}
