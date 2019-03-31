﻿using System.Collections.Generic;
using CM.Core;
using CM.DataAccess;
using CM.Domain.BLL.Base;

namespace CM.Domain.BLL
{
    public class DocumentoEntradaBLL : BaseBLL<DocumentoEntradaDTO>
    {
        public override DocumentoEntradaDTO Get(object id)
        {
            return Get<DocumentoEntrada>(id.ToString());
        }

        public override IEnumerable<DocumentoEntradaDTO> GetAll()
        {
            return GetAll<DocumentoEntrada>();
        }

        public override void Add(DocumentoEntradaDTO dto)
        {
            Add<Cliente>(dto);
        }

        public override void Update(DocumentoEntradaDTO dto)
        {
            Update<DocumentoEntrada>(dto);
        }

        public override void Remove(object id)
        {
            Remove<DocumentoEntrada>(id.ToString());
        }

        public void Incluir(DocumentoEntradaDTO documentoEntradaDTO)
        {
            Add(documentoEntradaDTO);

            var estoqueBll = new EstoqueBLL(ContextHelper);

            foreach (var item in documentoEntradaDTO.Itens)
            {
                estoqueBll.MovimentarEstoque(TipoMovimentoEstoque.Entrada, item.ProdutoId, item.Quantidade, item.ValorUnitario);
            }

            ContextHelper.Commit();
        }
    }
}