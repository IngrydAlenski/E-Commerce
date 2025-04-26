using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private IPedidoRepository PedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            PedidoRepository = pedidoRepository;
        }
    }

    [HttpPost]
    
}
