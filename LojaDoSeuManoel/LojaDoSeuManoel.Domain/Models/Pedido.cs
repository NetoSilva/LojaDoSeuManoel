namespace LojaDoSeuManoel.Domain.Models
{
    public class Pedido(int idPedido, IEnumerable<Produto> produtos)
    {
        public int IdPedido { get; set; } = idPedido;
        public IEnumerable<Produto> Produtos { get; set; } = produtos;
    }
}
