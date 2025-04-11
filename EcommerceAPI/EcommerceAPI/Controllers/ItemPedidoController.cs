using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IItemPedidoRepository itempedidoRepository;

        public ItemPedidoController(EcommerceContext context)
        {
            _context = context;
            itempedidoRepository = new ItemPedidoRepository(_context);
        }
    }
}
