using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CM.Domain.BLLs
{
    public class EstoqueBLL : BaseBLL<EstoqueDTO>
    {
        public EstoqueBLL(ContextHelper contextHelper) : base(contextHelper)
        {
        }

        public override EstoqueDTO Get(object id)
        {
            return Get<Estoque>(id.ToString());
        }

        public override IEnumerable<EstoqueDTO> GetAll()
        {
            return GetAll<Estoque>();
        }

        public override EstoqueDTO Add(EstoqueDTO dto)
        {
            return Add<Estoque>(dto, true);
        }

        public override void Update(EstoqueDTO dto)
        {
            Update<Estoque>(dto, true);
        }

        public override void Remove(object id)
        {
            Remove<Estoque>(id.ToString(), true);
        }

        public EstoqueDTO ObterEstoqueAtual(int produtoId)
        {
            var estoqueProduto = ContextHelper.DbSet.Find<Estoque>(m => m.ProdutoId == produtoId).ToList();

            var quantidade = estoqueProduto.Sum(m => m.Quantidade);
            var valorUnitario = estoqueProduto.Sum(m => m.ValorUnitario);
            var valorTotal = quantidade * valorUnitario;

            return new EstoqueDTO
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = valorTotal
            };
        }

        public void IncluirEstoqueInicial(int produtoId)
        {
            MovimentarEstoque(TipoMovimentoEstoque.Entrada, produtoId, 0, 0);
        }

        internal void RemoverEstoqueProduto(Produto produto)
        {
            var houveMovimentacaoEstoque = produto.Estoques.Count > 1;

            if (houveMovimentacaoEstoque)
                throw new ValidationException($"O produto [{produto.Nome}] não pode ser excluído porque já houve movimentação de estoque.");

            ContextHelper.DbSet.RemoveRange(produto.Estoques);
        }

        public void MovimentarEstoque(TipoMovimentoEstoque tipoMovimentoEstoque, int produtoId, int quantidade, decimal valorUnitario)
        {
            if (tipoMovimentoEstoque == TipoMovimentoEstoque.Saida)
            {
                ValidarSaldoEstoque(produtoId, quantidade);
            }

            quantidade = tipoMovimentoEstoque == TipoMovimentoEstoque.Saida
                ? quantidade * -1
                : quantidade;

            ContextHelper.DbSet.Add(new Estoque
            {
                ProdutoId = produtoId,
                Data = DateTime.Now,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = quantidade * valorUnitario
            });
        }

        public void ValidarSaldoEstoque(int produtoId, int quantidadeSaida)
        {
            var estoqueAtual = ObterEstoqueAtual(produtoId);

            if (estoqueAtual.Quantidade - quantidadeSaida < 0)
            {
                var produto = ContextHelper.DbSet.Get<Produto>(produtoId);

                throw new ValidationException($"Estoque insuficiente do produto [{produtoId} - {produto.Nome}].\r\nEstoque atual : {estoqueAtual.Quantidade}\r\nQuantidade a baixar : {quantidadeSaida}");
            }
        }
    }
}
