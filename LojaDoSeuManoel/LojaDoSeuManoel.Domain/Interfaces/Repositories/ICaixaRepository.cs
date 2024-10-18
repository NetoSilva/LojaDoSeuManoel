using LojaDoSeuManoel.Domain.Models;

namespace LojaDoSeuManoel.Domain.Interfaces.Repositories
{
    public interface ICaixaRepository
    {
        public List<Caixa> GetCaixas();
    }
}
