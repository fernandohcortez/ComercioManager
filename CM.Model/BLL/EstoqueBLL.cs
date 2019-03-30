using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLL.Base;

namespace CM.Domain.BLL
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

        public override void Add(EstoqueDTO dto)
        {
            Add<Estoque>(dto);
        }

        public override void Update(EstoqueDTO dto)
        {
            Update<Estoque>(dto);
        }

        public override void Remove(object id)
        {
            Remove<Estoque>(id.ToString());
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
