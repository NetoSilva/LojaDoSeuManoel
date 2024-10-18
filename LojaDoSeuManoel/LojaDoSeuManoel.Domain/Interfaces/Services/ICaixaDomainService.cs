using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Domain.Interfaces.Services
{
    public interface ICaixaDomainService
    {
        public bool CalcularMelhorCaixa(Dimensao dimensaoProduto, Dimensao dimensaoCaixa);
    }
}
