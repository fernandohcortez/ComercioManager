using System.Data.Entity;
using System.Linq;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class EstoqueRepository : Repository<Estoque, CMDataEntities>, IEstoqueRepository
    {
        public EstoqueRepository(DbContext context) : base(context)
        {
            
        }

        public Estoque ObterEstoqueAtual(Produto produto)
        {
            //Verificar se produto.Estoque funciona.
            //var estoqueProduto = Find(m => m.ProdutoId == produto.Id).ToList();

            var quantidade = produto.Estoques.Sum(m => m.Quantidade);
            var valorUnitario = produto.Estoques.Sum(m => m.ValorUnitario);
            var valorTotal = quantidade * valorUnitario;

            return new Estoque
            {
                ProdutoId = produto.Id,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = valorTotal
            };
        }
    }
}
