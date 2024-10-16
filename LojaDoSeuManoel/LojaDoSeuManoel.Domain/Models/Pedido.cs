namespace LojaDoSeuManoel.Domain.Models
{
    public class Pedido()
    {
        public required int IdPedido { get; set; }
        public required IEnumerable<Produto>  Produtos { get; set; }
    }
}
