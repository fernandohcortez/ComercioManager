using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CM.DataAccess;

namespace CM.Domain
{
    public class EstoqueDomain
    {
        public Estoque ObterEstoqueAtual(Produto produto)
        {
            //var context = ContextHelper.CriarInstancia();
            //var estoqueProduto = context.DbSet.Find<Estoque>(m => m.ProdutoId == produto.Id).ToList();
            //context.Commit();

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
