using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Application.AppServices
{
    public class CaixasAppService(ICaixaDomainService caixaDomainService, ICaixaRepository caixaRepository) : ICaixasAppService
    {
        private readonly ICaixaDomainService _caixaDomainService = caixaDomainService;
        private readonly ICaixaRepository _caixaRepository = caixaRepository;

        public bool CalcularMelhorCaixa(Dimensao dimensaoProduto, Dimensao dimensaoCaixa)
        {
            return _caixaDomainService.CalcularMelhorCaixa(dimensaoProduto, dimensaoCaixa);
        }

        public List<Caixa> GetCaixas()
        {
            return _caixaRepository.GetCaixas();
        }
    }
}
