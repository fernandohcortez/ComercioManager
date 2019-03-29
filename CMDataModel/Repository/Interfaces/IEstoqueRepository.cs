using CM.DataAccess.Repository.Base;

namespace CM.DataAccess.Repository.Interfaces
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        Estoque ObterEstoqueAtual(Produto produto);
    }
}
