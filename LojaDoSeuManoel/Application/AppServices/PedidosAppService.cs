using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Application.Results;
using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Application.AppServices
{
    public class PedidosAppService(ICaixasAppService caixasAppService) : IPedidosAppService
    {
        private readonly ICaixasAppService _caixasAppService = caixasAppService;

        public PedidosAppServiceProcessResult ProcessarPedido(Pedido pedido)
        {
            var caixas = _caixasAppService.GetCaixas();
            var result = new PedidosAppServiceProcessResult() { PedidoId = pedido.IdPedido, CaixasDictionary = new Dictionary<string, List<string>>()};

            foreach (var produto in pedido.Produtos)
            {
                foreach (var caixa in caixas)
                {
                    var coube = _caixasAppService.CalcularMelhorCaixa(produto.Dimensao, caixa.Dimensao);
                    if (coube)
                    {
                        if(result.CaixasDictionary.ContainsKey(caixa.IdCaixa))
                        {
                            ((List<string>)result.CaixasDictionary[caixa.IdCaixa]).Add(produto.IdProduto);
                        }
                        else
                        {
                            result.CaixasDictionary.Add(caixa.IdCaixa, new List<string>() { produto.IdProduto });
                        }
                        break;
                    }
                }
            }

            return result;
        }
    }
}
