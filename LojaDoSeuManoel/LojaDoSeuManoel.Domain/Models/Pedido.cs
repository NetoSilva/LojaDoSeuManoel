namespace LojaDoSeuManoel.Domain.Models
{
    public class Pedido()
    {
        public int IdPedido { get; set; }
        public IEnumerable<Produto>  Produtos { get; set; }
    }
}
