CREATE TABLE [dbo].[PedidoVendaItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PedidoVendaId] INT NOT NULL, 
    [ProdutoId] INT NOT NULL, 
	[Quantidade] INT NOT NULL DEFAULT 1,
    [ValorUnitario] MONEY NOT NULL DEFAULT 0, 
    [Imposto] MONEY NOT NULL DEFAULT 0, 
    [ValorTotal] MONEY NOT NULL DEFAULT 0, 
    
)
