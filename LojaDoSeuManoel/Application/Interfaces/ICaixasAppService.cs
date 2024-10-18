using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface ICaixasAppService
    {
        public bool CalcularMelhorCaixa(Dimensao dimensaoProduto, Dimensao dimensaoCaixa);
        public List<Caixa> GetCaixas();

    }
}
