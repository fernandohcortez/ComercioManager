using System;
using System.ComponentModel.DataAnnotations;
using CM.DataAccess;
using CM.DataAccess.Repository.UnitOfWork;
using CM.WebApi;
using CM.WebApi.BLL.Base;

namespace CM.WebApi.BLL
{
    public class EstoqueBll : BllBase
    {
        public EstoqueBll(IUnitOfWork uoW) : base(uoW)
        {

        }

        public void IncluirEstoqueInicial(Produto produto)
        {
            MovimentarEstoque(TipoMovimentoEstoque.Entrada, produto, 0, 0);
        }

        public void MovimentarEstoque(TipoMovimentoEstoque tipoMovimentoEstoque, Produto produto, int quantidade, decimal valorUnitario)
        {
            if (tipoMovimentoEstoque == TipoMovimentoEstoque.Saida)
            {
                ValidarSaldoEstoque(produto, quantidade);
            }

            quantidade = tipoMovimentoEstoque == TipoMovimentoEstoque.Saida 
                ? quantidade * -1 
                : quantidade;

            UoW.Estoque.Add(new Estoque
            {
                ProdutoId = produto.Id,
                Data = DateTime.Now,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = quantidade * valorUnitario
            });
        }

        public void ValidarSaldoEstoque(Produto produto, int quantidadeSaida)
        {
            var estoqueAtual = UoW.Estoque.ObterEstoqueAtual(produto);

            if (estoqueAtual.Quantidade - quantidadeSaida < 0)
            {
                throw new ValidationException($"Estoque insuficiente do produto [{produto.Id} - {produto.Nome}].\r\nEstoque atual : {estoqueAtual.Quantidade}\r\nQuantidade a baixar : {quantidadeSaida}");
            }
        }
    }
}