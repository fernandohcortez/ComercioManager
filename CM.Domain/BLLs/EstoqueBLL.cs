using CM.Core;
using CM.DataAccess;
using CM.Domain.BLLs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CM.Domain.Helpers;
using Helpers;

namespace CM.Domain.BLLs
{
    public class EstoqueBLL : BaseBLL<EstoqueDTO>
    {
        public EstoqueBLL(ContextHelper contextHelper) : base(contextHelper)
        {
        }

        public override async Task<EstoqueDTO> GetAsync(object id)
        {
            return await GetAsync<Estoque>(id.IsNullOrEmptyThenZero());
        }

        public override async Task<IEnumerable<EstoqueDTO>> GetAllAsync()
        {
            return await GetAllAsync<Estoque>();
        }

        public override async Task<EstoqueDTO> AddAsync(EstoqueDTO dto)
        {
            return await AddAsync<Estoque>(dto, true);
        }

        public override async Task UpdateAsync(EstoqueDTO dto)
        {
            await UpdateAsync<Estoque>(dto, true);
        }

        public override async Task RemoveAsync(object id)
        {
            await RemoveAsync<Estoque>(id.IsNullOrEmptyThenZero(), true);
        }

        public async Task<EstoqueDTO> ObterEstoqueAtualAsync(int produtoId)
        {
            var estoqueProduto = await ContextHelper.DbSet.FindAsync<Estoque>(m => m.ProdutoId == produtoId);

            var listaEstoqueProduto = estoqueProduto.ToList();

            var quantidade = listaEstoqueProduto.Sum(m => m.Quantidade);
            var valorUnitario = listaEstoqueProduto.Sum(m => m.ValorUnitario);
            var valorTotal = quantidade * valorUnitario;

            return new EstoqueDTO
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = valorTotal
            };
        }

        public async Task IncluirEstoqueInicialAsync(int produtoId)
        {
            await MovimentarEstoqueAsync(TipoMovimentoEstoque.Entrada, produtoId, 0, 0);
        }

        internal async Task RemoverEstoqueProdutoAsync(Produto produto)
        {
            var houveMovimentacaoEstoque = produto.Estoques.Count > 1;

            if (houveMovimentacaoEstoque)
                throw new ValidationException($"O produto [{produto.Nome}] não pode ser excluído porque já houve movimentação de estoque.");

            await ContextHelper.DbSet.RemoveRangeAsync(produto.Estoques);
        }

        public async Task MovimentarEstoqueAsync(TipoMovimentoEstoque tipoMovimentoEstoque, int produtoId, int quantidade, decimal valorUnitario)
        {
            if (tipoMovimentoEstoque == TipoMovimentoEstoque.Saida)
            {
                await ValidarSaldoEstoqueAsync(produtoId, quantidade);
            }

            quantidade = tipoMovimentoEstoque == TipoMovimentoEstoque.Saida
                ? quantidade * -1
                : quantidade;

            await ContextHelper.DbSet.AddAsync(new Estoque
            {
                ProdutoId = produtoId,
                Data = DateTime.Now,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = quantidade * valorUnitario
            });
        }

        public async Task ValidarSaldoEstoqueAsync(int produtoId, int quantidadeSaida)
        {
            var estoqueAtual = await ObterEstoqueAtualAsync(produtoId);

            if (estoqueAtual.Quantidade - quantidadeSaida < 0)
            {
                var produto = await ContextHelper.DbSet.GetAsync<Produto>(produtoId);

                throw new ValidationException($"Estoque insuficiente do produto [{produtoId} - {produto.Nome}].\r\nEstoque atual : {estoqueAtual.Quantidade}\r\nQuantidade a baixar : {quantidadeSaida}");
            }
        }
    }
}
