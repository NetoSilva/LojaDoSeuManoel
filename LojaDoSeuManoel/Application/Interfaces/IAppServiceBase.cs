using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        public T Process(Pedido pedido);
    }
}
