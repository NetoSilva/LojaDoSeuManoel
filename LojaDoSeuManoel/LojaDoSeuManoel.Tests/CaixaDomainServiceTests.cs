using LojaDoSeuManoel.Domain.Interfaces.Services;
using LojaDoSeuManoel.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LojaDoSeuManoel.Tests
{
    public class CaixaDomainServiceTests : TestBase
    {
        private readonly ICaixaDomainService _caixaDomainService;

        public CaixaDomainServiceTests()
        {
            _caixaDomainService = ServiceProvider.GetRequiredService<ICaixaDomainService>();
        }

        [Fact]
        public void CalcularMelhorCaixa_DeveRetornarVerdadeiro_SeProdutoCabeNaCaixa()
        {
            // Arrange
            var dimensaoProduto = new Dimensao { Altura = 10, Largura = 5, Comprimento = 8 };
            var dimensaoCaixa = new Dimensao { Altura = 12, Largura = 6, Comprimento = 10 };

            // Act
            bool resultado = _caixaDomainService.CalcularMelhorCaixa(dimensaoProduto, dimensaoCaixa);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void CalcularMelhorCaixa_DeveRetornarFalso_SeProdutoNaoCabeNaCaixa()
        {
            // Arrange
            var dimensaoProduto = new Dimensao { Altura = 15, Largura = 10, Comprimento = 12 };
            var dimensaoCaixa = new Dimensao { Altura = 10, Largura = 5, Comprimento = 8 };
            var caixa = new Caixa();

            // Act
            bool resultado = _caixaDomainService.CalcularMelhorCaixa(dimensaoProduto, dimensaoCaixa);

            // Assert
            Assert.False(resultado);
        }
    }
}
