namespace LojaDoSeuManoel.Tests
{
    using Xunit;
    using Moq;
    using System.Collections.Generic;
    using LojaDoSeuManoel.Domain.Models;
    using LojaDoSeuManoel.Application.Interfaces;
    using LojaDoSeuManoel.Application.AppServices;

    public class PedidosAppServiceTests : TestBase
    {
        private readonly IPedidosAppService _pedidosAppService;
        private readonly Mock<ICaixasAppService> _caixasAppServiceMock;
        public PedidosAppServiceTests()
        {
            _caixasAppServiceMock = new Mock<ICaixasAppService>();
            _pedidosAppService = new PedidosAppService(_caixasAppServiceMock.Object);
        }

        [Fact]
        public void ProcessarPedido_DeveAdicionarProdutoNaCaixaCorreta_QuandoProdutoCabeNaCaixa()
        {
            // Arrange
            var pedido = new Pedido
            {
                IdPedido = 1,
                Produtos = new List<Produto>
            {
                new Produto { IdProduto = "produto1", Dimensao = new Dimensao { Altura = 10, Largura = 5, Comprimento = 5 } }
            }
            };

            var caixas = new List<Caixa>
        {
            new Caixa { IdCaixa = "caixa1", Dimensao = new Dimensao { Altura = 15, Largura = 10, Comprimento = 10 } }
        };

            _caixasAppServiceMock.Setup(s => s.GetCaixas()).Returns(caixas);
            _caixasAppServiceMock.Setup(s => s.CalcularMelhorCaixa(It.IsAny<Dimensao>(), It.IsAny<Dimensao>())).Returns(true);

                // Act
                var result = _pedidosAppService.ProcessarPedido(pedido);

            // Assert
            Assert.Equal(1, result.PedidoId);
            Assert.True(result.CaixasDictionary.ContainsKey("caixa1"));
            Assert.Contains("produto1", result.CaixasDictionary["caixa1"]);
        }

        [Fact]
        public void ProcessarPedido_DeveRetornarCaixasVazia_QuandoProdutoNaoCabeEmNenhumaCaixa()
        {
            // Arrange
            var pedido = new Pedido
            {
                IdPedido = 2,
                Produtos = new List<Produto>
            {
                new Produto { IdProduto = "produto2", Dimensao = new Dimensao { Altura = 20, Largura = 15, Comprimento = 15 } }
            }
            };

            var caixas = new List<Caixa>
        {
            new Caixa { IdCaixa = "caixa2", Dimensao = new Dimensao { Altura = 10, Largura = 10, Comprimento = 10 } }
        };

            _caixasAppServiceMock.Setup(s => s.GetCaixas()).Returns(caixas);
            _caixasAppServiceMock.Setup(s => s.CalcularMelhorCaixa(It.IsAny<Dimensao>(), It.IsAny<Dimensao>())).Returns(false);

            // Act
            var result = _pedidosAppService.ProcessarPedido(pedido);

            // Assert
            Assert.Equal(2, result.PedidoId);
            Assert.False(result.CaixasDictionary.ContainsKey("caixa2"));
        }

    }
}
