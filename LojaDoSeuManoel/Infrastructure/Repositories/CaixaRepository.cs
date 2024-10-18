
using LojaDoSeuManoel.Domain.Constants;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Models;

namespace Infrastructure.Repositories
{
    public class CaixaRepository : ICaixaRepository
    {
        public List<Caixa> GetCaixas()
        {
            return new[] 
            {
                new Caixa() { IdCaixa = TipoCaixa.Caixa1, Dimensao = new Dimensao(){ Altura = 30, Largura = 40, Comprimento = 80 } },
                new Caixa() { IdCaixa = TipoCaixa.Caixa2, Dimensao = new Dimensao(){ Altura = 80, Largura = 50, Comprimento = 40 } },
                new Caixa() { IdCaixa = TipoCaixa.Caixa3, Dimensao = new Dimensao(){ Altura = 50, Largura = 80, Comprimento = 60 } }

            }.OrderBy(c => c.Dimensao.ObterVolume()).ToList();
        }
    }
}
