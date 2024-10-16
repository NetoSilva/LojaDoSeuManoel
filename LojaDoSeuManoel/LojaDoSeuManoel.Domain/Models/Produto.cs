namespace LojaDoSeuManoel.Domain.Models
{
    public class Produto(string idProduto, Dimensao dimensao)
    {
        public string IdProduto { get; set; } = idProduto;
        public Dimensao Dimensao { get; set; } = dimensao;
    }
}
