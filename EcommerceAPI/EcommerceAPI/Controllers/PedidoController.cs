using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly EcommerceContext _context;

        private IPedidoRepository pedidoRepository;

        public PedidoController(EcommerceContext context)
        {
            _context = context;
            pedidoRepository = new IPedidoRepository(_context);
        }
    }
}
