using LojaDoSeuManoel.Domain.Interfaces.Services;
using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Domain.DomainServices
{
    public class CaixaDomainService: ICaixaDomainService
    {
        public bool CalcularMelhorCaixa(Dimensao dimensaoProduto, Dimensao dimensaoCaixa)
        {
            return (dimensaoProduto.Altura <= dimensaoCaixa.Altura && dimensaoProduto.Largura <= dimensaoCaixa.Largura && dimensaoProduto.Comprimento <= dimensaoCaixa.Comprimento) ||
                   (dimensaoProduto.Altura <= dimensaoCaixa.Altura && dimensaoProduto.Largura <= dimensaoCaixa.Comprimento && dimensaoProduto.Comprimento <= dimensaoCaixa.Largura) ||
                   (dimensaoProduto.Altura <= dimensaoCaixa.Largura && dimensaoProduto.Largura <= dimensaoCaixa.Comprimento && dimensaoProduto.Comprimento <= dimensaoCaixa.Altura) ||
                   (dimensaoProduto.Altura <= dimensaoCaixa.Largura && dimensaoProduto.Largura <= dimensaoCaixa.Altura && dimensaoProduto.Comprimento <= dimensaoCaixa.Comprimento) ||
                   (dimensaoProduto.Altura <= dimensaoCaixa.Comprimento && dimensaoProduto.Largura <= dimensaoCaixa.Altura && dimensaoProduto.Comprimento <= dimensaoCaixa.Largura) ||
                   (dimensaoProduto.Altura <= dimensaoCaixa.Comprimento && dimensaoProduto.Largura <= dimensaoCaixa.Largura && dimensaoProduto.Comprimento <= dimensaoCaixa.Altura);
        }
    }
}
