CREATE TABLE [dbo].[Estoque]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProdutoId] INT NOT NULL, 
    [Quantidade] INT NOT NULL DEFAULT 1, 
    [ValorUnitario] MONEY NOT NULL DEFAULT 0, 
    [ValorTotal] MONEY NOT NULL DEFAULT 0, 
    [Data] DATETIME2 NOT NULL DEFAULT getutcdate()
)
