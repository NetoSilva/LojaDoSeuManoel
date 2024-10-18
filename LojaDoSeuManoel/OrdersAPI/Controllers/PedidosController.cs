using AutoMapper;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Requests;
using PedidosAPI.Responses;

namespace PedidosAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidosController(IPedidosAppService pedidosAppService, IMapper mapper) : ControllerBase
    {
        private readonly IPedidosAppService _pedidosAppService = pedidosAppService;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [Authorize]
        public ProcessarPedidosResponse ProcessarPedidos(ProcessarPedidosRequest request)
        {
            var response = new ProcessarPedidosResponse();
            response.Pedidos = new List<Responses.PedidoResponse>();

            foreach (var pedido in request.PedidosDTO)
            {
                var pedidoDomain = _mapper.Map<Pedido>(pedido);
                var result = _pedidosAppService.ProcessarPedido(pedidoDomain);

               response.Pedidos.Add(new PedidoResponse() {IdPedido = result.PedidoId, Caixas = result.CaixasDictionary});
            }

            return response;
        }
    }
}
