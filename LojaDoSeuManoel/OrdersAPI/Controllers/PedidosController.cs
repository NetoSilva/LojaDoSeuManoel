using AutoMapper;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Requests;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosAppService _pedidosAppService;
        private readonly IMapper _mapper;
        public PedidosController(IPedidosAppService pedidosAppService, IMapper mapper)
        {
            _pedidosAppService = pedidosAppService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public void ProcessarPedidos(ProcessarPedidosRequest request)
        {
            Parallel.For(0, request?.PedidosDTO?.Length?? 0, i =>
            {
                var pedido = _mapper.Map<Pedido>(request?.PedidosDTO?[i]);
                _pedidosAppService.Process(pedido);
            });
        }
    }
}
