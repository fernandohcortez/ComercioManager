﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMDataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CMDataEntities : DbContext
    {
        public CMDataEntities()
            : base("name=CMDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<PedidoVenda> PedidoVenda { get; set; }
        public virtual DbSet<PedidoVendaItem> PedidoVendaItem { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<DocumentoEntrada> DocumentoEntrada { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DocumentoEntradaItem> DocumentoEntradaItem { get; set; }
    }
}
