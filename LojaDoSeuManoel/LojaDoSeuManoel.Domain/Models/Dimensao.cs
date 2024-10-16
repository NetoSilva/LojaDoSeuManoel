namespace LojaDoSeuManoel.Domain.Models
{
    public class Dimensao(double altura, double largura, double comprimento)
    {
        public double Altura { get; set; } = altura;
        public double Largura { get; set; } = largura;
        public double Comprimento { get; set; } = comprimento;
    }
}
