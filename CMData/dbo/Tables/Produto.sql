CREATE TABLE [dbo].[Produto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(100) NOT NULL, 
    [Descricao] NVARCHAR(MAX) NULL, 
	[PrecoVenda] MONEY NOT NULL DEFAULT 0,
    [DataInclusao] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DataAlteracao] DATETIME2 NOT NULL DEFAULT getutcdate()
)
