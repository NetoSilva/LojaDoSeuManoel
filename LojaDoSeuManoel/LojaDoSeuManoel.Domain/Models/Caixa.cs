namespace LojaDoSeuManoel.Domain.Models
{
    public class Caixa (string idCaixa, Dimensao dimensao)
    {
        public required string IdCaixa { get; set; } = idCaixa;
        public Dimensao Dimensao { get; set; } = dimensao;
    }
}
