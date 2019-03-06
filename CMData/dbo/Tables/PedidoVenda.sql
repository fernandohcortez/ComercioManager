CREATE TABLE [dbo].[PedidoVenda]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UsuarioIdCaixa] NVARCHAR(128) NOT NULL, 
    [Data] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [SubTotal] MONEY NOT NULL DEFAULT 0, 
    [Imposto] MONEY NOT NULL DEFAULT 0, 
    [Total] MONEY NOT NULL DEFAULT 0, 
    [DataInclusao] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DataAlteracao] DATETIME2 NOT NULL DEFAULT getutcdate()
)
