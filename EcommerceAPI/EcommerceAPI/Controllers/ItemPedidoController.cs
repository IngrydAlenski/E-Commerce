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
        private readonly EcommerceContext _context;

        private Interfaces.IItemPedidoRepository itempedidoRepository;

        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            itempedidoRepository = new Repositories.ItemPedidoRepository(_context);
        }
    }
}
