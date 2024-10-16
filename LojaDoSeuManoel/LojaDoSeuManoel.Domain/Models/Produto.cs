namespace LojaDoSeuManoel.Domain.Models
{
    public class Produto()
    {
        public required string IdProduto { get; set; }
        public required Dimensao Dimensao { get; set; }
    }
}
