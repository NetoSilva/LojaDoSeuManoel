using LojaDoSeuManoel.Application.Results;
using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface IPedidosAppService
    {
        public PedidosAppServiceProcessResult ProcessarPedido(Pedido pedido);
    }
}
