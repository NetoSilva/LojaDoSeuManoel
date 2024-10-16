namespace LojaDoSeuManoel.Domain.Models
{
    public class Caixa ()
    {
        public required string IdCaixa { get; set; }
        public Dimensao Dimensao { get; set; }
    }
}
