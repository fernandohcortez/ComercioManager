//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CM.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocumentoEntrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentoEntrada()
        {
            this.Itens = new HashSet<DocumentoEntradaItem>();
        }
    
        public int Id { get; set; }
        public string SerieNF { get; set; }
        public string NumeroNF { get; set; }
        public System.DateTime Data { get; set; }
        public int FornecedorId { get; set; }
        public decimal ValorSubTotal { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal ValorTotal { get; set; }
        public System.DateTime DataInclusao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public string Status { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentoEntradaItem> Itens { get; set; }
    }
}