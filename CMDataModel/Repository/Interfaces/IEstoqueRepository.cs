using CMDataModel.Repository.Base;

namespace CMDataModel.Repository.Interfaces
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        Estoque ObterEstoqueAtual(Produto produto);
    }
}
