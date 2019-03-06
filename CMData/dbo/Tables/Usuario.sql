CREATE TABLE [dbo].[Usuario]
(
    [Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [PrimeiroNome] NVARCHAR(50) NOT NULL, 
    [UltimoNome] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
    [DataInclusao] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DataAlteracao] DATETIME2 NOT NULL DEFAULT getutcdate()
)
