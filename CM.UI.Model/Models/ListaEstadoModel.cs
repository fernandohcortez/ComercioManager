using System.Collections.Generic;

namespace CM.UI.Model.Models
{
    public class ListaEstadoModel
    {
        public List<EstadoModel> Estados { get; }

        public ListaEstadoModel()
        {
            Estados = new List<EstadoModel>
            {
                new EstadoModel {Estado = "AC", Descricao = "Acre"},
                new EstadoModel {Estado = "AL", Descricao = "Alagoas"},
                new EstadoModel {Estado = "AP", Descricao = "Amapá"},
                new EstadoModel {Estado = "AM", Descricao = "Amazonas"},
                new EstadoModel {Estado = "BA", Descricao = "Bahia"},
                new EstadoModel {Estado = "CE", Descricao = "Ceará"},
                new EstadoModel {Estado = "DF", Descricao = "Distrito Federal"},
                new EstadoModel {Estado = "ES", Descricao = "Espírito Santo"},
                new EstadoModel {Estado = "GO", Descricao = "Goiás"},
                new EstadoModel {Estado = "MA", Descricao = "Maranhão"},
                new EstadoModel {Estado = "MT", Descricao = "Mato Grosso"},
                new EstadoModel {Estado = "MS", Descricao = "Mato Grosso do Sul"},
                new EstadoModel {Estado = "MG", Descricao = "Minas Gerais"},
                new EstadoModel {Estado = "PA", Descricao = "Pará"},
                new EstadoModel {Estado = "PB", Descricao = "Paraíba"},
                new EstadoModel {Estado = "PR", Descricao = "Paraná"},
                new EstadoModel {Estado = "PE", Descricao = "Pernanbuco"},
                new EstadoModel {Estado = "PI", Descricao = "Piauí"},
                new EstadoModel {Estado = "RJ", Descricao = "Rio de Janeiro"},
                new EstadoModel {Estado = "RN", Descricao = "Rio Grande do Norte"},
                new EstadoModel {Estado = "RS", Descricao = "Rio Grande do Sul"},
                new EstadoModel {Estado = "RO", Descricao = "Rondônia"},
                new EstadoModel {Estado = "RR", Descricao = "Roraima"},
                new EstadoModel {Estado = "SC", Descricao = "Santa Catarina"},
                new EstadoModel {Estado = "SP", Descricao = "São Paulo"},
                new EstadoModel {Estado = "SE", Descricao = "Sergipe"},
                new EstadoModel {Estado = "TO", Descricao = "Tocantis"},
            };

        }
    }
}
