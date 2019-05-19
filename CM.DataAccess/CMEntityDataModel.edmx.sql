
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2019 12:03:00
-- Generated from EDMX file: C:\ProjetosVS\ComercioManager\CM.DataAccess\CMEntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CMData];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PedidoVendaItemPedidoVenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoVendaItem] DROP CONSTRAINT [FK_PedidoVendaItemPedidoVenda];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoVendaItemProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoVendaItem] DROP CONSTRAINT [FK_PedidoVendaItemProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoVendaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoVenda] DROP CONSTRAINT [FK_PedidoVendaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_EstoqueProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estoque] DROP CONSTRAINT [FK_EstoqueProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentoEntradaFornecedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentoEntrada] DROP CONSTRAINT [FK_DocumentoEntradaFornecedor];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentoEntradaItemDocumentoEntrada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentoEntradaItem] DROP CONSTRAINT [FK_DocumentoEntradaItemDocumentoEntrada];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentoEntradaItemProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentoEntradaItem] DROP CONSTRAINT [FK_DocumentoEntradaItemProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoVendaCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoVenda] DROP CONSTRAINT [FK_PedidoVendaCliente];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Estoque]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estoque];
GO
IF OBJECT_ID(N'[dbo].[PedidoVenda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoVenda];
GO
IF OBJECT_ID(N'[dbo].[PedidoVendaItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoVendaItem];
GO
IF OBJECT_ID(N'[dbo].[Produto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produto];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[DocumentoEntrada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentoEntrada];
GO
IF OBJECT_ID(N'[dbo].[Fornecedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[DocumentoEntradaItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentoEntradaItem];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Estoque'
CREATE TABLE [dbo].[Estoque] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantidade] int  NOT NULL,
    [ValorUnitario] decimal(19,4)  NOT NULL,
    [ValorTotal] decimal(19,4)  NOT NULL,
    [Data] datetime  NOT NULL,
    [ProdutoId] int  NOT NULL
);
GO

-- Creating table 'PedidoVenda'
CREATE TABLE [dbo].[PedidoVenda] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NOT NULL,
    [ValorSubTotal] decimal(19,4)  NOT NULL,
    [ValorImposto] decimal(19,4)  NOT NULL,
    [ValorTotal] decimal(19,4)  NOT NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL,
    [UsuarioIdCaixa] nvarchar(256)  NOT NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'PedidoVendaItem'
CREATE TABLE [dbo].[PedidoVendaItem] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantidade] int  NOT NULL,
    [ValorUnitario] decimal(19,4)  NOT NULL,
    [ValorImposto] decimal(19,4)  NOT NULL,
    [ValorTotal] decimal(19,4)  NOT NULL,
    [PedidoVendaId] int  NOT NULL,
    [ProdutoId] int  NOT NULL
);
GO

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(100)  NOT NULL,
    [Descricao] nvarchar(max)  NULL,
    [PrecoVenda] decimal(19,4)  NOT NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] nvarchar(256)  NOT NULL,
    [PrimeiroNome] nvarchar(50)  NOT NULL,
    [UltimoNome] nvarchar(50)  NOT NULL,
    [Email] nvarchar(256)  NOT NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL,
    [Foto] varbinary(max)  NULL,
    [Administrador] bit  NOT NULL
);
GO

-- Creating table 'DocumentoEntrada'
CREATE TABLE [dbo].[DocumentoEntrada] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SerieNF] nvarchar(3)  NULL,
    [NumeroNF] nvarchar(15)  NULL,
    [Data] datetime  NOT NULL,
    [FornecedorId] int  NOT NULL,
    [ValorSubTotal] decimal(18,0)  NOT NULL,
    [ValorImposto] decimal(18,0)  NOT NULL,
    [ValorTotal] decimal(18,0)  NOT NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL,
    [Status] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RazaoSocial] nvarchar(100)  NOT NULL,
    [NomeFantasia] nvarchar(70)  NULL,
    [Cnpj] nvarchar(18)  NOT NULL,
    [InscricaoEstadual] nvarchar(15)  NULL,
    [Fone1] nvarchar(14)  NULL,
    [Fone2] nvarchar(14)  NULL,
    [Endereco] nvarchar(100)  NULL,
    [Complemento] nvarchar(100)  NULL,
    [Bairro] nvarchar(70)  NULL,
    [Cidade] nvarchar(70)  NULL,
    [Estado] nvarchar(2)  NULL,
    [Email] nvarchar(256)  NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(70)  NOT NULL,
    [Cpf] nvarchar(14)  NULL,
    [Fone1] nvarchar(14)  NULL,
    [Fone2] nvarchar(14)  NULL,
    [DataNascimento] datetime  NULL,
    [Endereco] nvarchar(200)  NULL,
    [Complemento] nvarchar(100)  NULL,
    [Bairro] nvarchar(70)  NULL,
    [Cidade] nvarchar(70)  NULL,
    [Estado] nvarchar(2)  NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL,
    [Email] nvarchar(256)  NULL
);
GO

-- Creating table 'DocumentoEntradaItem'
CREATE TABLE [dbo].[DocumentoEntradaItem] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentoEntradaId] int  NOT NULL,
    [Quantidade] int  NOT NULL,
    [ValorUnitario] decimal(18,0)  NOT NULL,
    [ValorImposto] decimal(18,0)  NOT NULL,
    [ValorTotal] decimal(18,0)  NOT NULL,
    [ProdutoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Estoque'
ALTER TABLE [dbo].[Estoque]
ADD CONSTRAINT [PK_Estoque]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PedidoVenda'
ALTER TABLE [dbo].[PedidoVenda]
ADD CONSTRAINT [PK_PedidoVenda]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PedidoVendaItem'
ALTER TABLE [dbo].[PedidoVendaItem]
ADD CONSTRAINT [PK_PedidoVendaItem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [PK_Produto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentoEntrada'
ALTER TABLE [dbo].[DocumentoEntrada]
ADD CONSTRAINT [PK_DocumentoEntrada]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentoEntradaItem'
ALTER TABLE [dbo].[DocumentoEntradaItem]
ADD CONSTRAINT [PK_DocumentoEntradaItem]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PedidoVendaId] in table 'PedidoVendaItem'
ALTER TABLE [dbo].[PedidoVendaItem]
ADD CONSTRAINT [FK_PedidoVendaItemPedidoVenda]
    FOREIGN KEY ([PedidoVendaId])
    REFERENCES [dbo].[PedidoVenda]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoVendaItemPedidoVenda'
CREATE INDEX [IX_FK_PedidoVendaItemPedidoVenda]
ON [dbo].[PedidoVendaItem]
    ([PedidoVendaId]);
GO

-- Creating foreign key on [ProdutoId] in table 'PedidoVendaItem'
ALTER TABLE [dbo].[PedidoVendaItem]
ADD CONSTRAINT [FK_PedidoVendaItemProduto]
    FOREIGN KEY ([ProdutoId])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoVendaItemProduto'
CREATE INDEX [IX_FK_PedidoVendaItemProduto]
ON [dbo].[PedidoVendaItem]
    ([ProdutoId]);
GO

-- Creating foreign key on [UsuarioIdCaixa] in table 'PedidoVenda'
ALTER TABLE [dbo].[PedidoVenda]
ADD CONSTRAINT [FK_PedidoVendaUsuario]
    FOREIGN KEY ([UsuarioIdCaixa])
    REFERENCES [dbo].[Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoVendaUsuario'
CREATE INDEX [IX_FK_PedidoVendaUsuario]
ON [dbo].[PedidoVenda]
    ([UsuarioIdCaixa]);
GO

-- Creating foreign key on [ProdutoId] in table 'Estoque'
ALTER TABLE [dbo].[Estoque]
ADD CONSTRAINT [FK_EstoqueProduto]
    FOREIGN KEY ([ProdutoId])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstoqueProduto'
CREATE INDEX [IX_FK_EstoqueProduto]
ON [dbo].[Estoque]
    ([ProdutoId]);
GO

-- Creating foreign key on [FornecedorId] in table 'DocumentoEntrada'
ALTER TABLE [dbo].[DocumentoEntrada]
ADD CONSTRAINT [FK_DocumentoEntradaFornecedor]
    FOREIGN KEY ([FornecedorId])
    REFERENCES [dbo].[Fornecedor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentoEntradaFornecedor'
CREATE INDEX [IX_FK_DocumentoEntradaFornecedor]
ON [dbo].[DocumentoEntrada]
    ([FornecedorId]);
GO

-- Creating foreign key on [DocumentoEntradaId] in table 'DocumentoEntradaItem'
ALTER TABLE [dbo].[DocumentoEntradaItem]
ADD CONSTRAINT [FK_DocumentoEntradaItemDocumentoEntrada]
    FOREIGN KEY ([DocumentoEntradaId])
    REFERENCES [dbo].[DocumentoEntrada]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentoEntradaItemDocumentoEntrada'
CREATE INDEX [IX_FK_DocumentoEntradaItemDocumentoEntrada]
ON [dbo].[DocumentoEntradaItem]
    ([DocumentoEntradaId]);
GO

-- Creating foreign key on [ProdutoId] in table 'DocumentoEntradaItem'
ALTER TABLE [dbo].[DocumentoEntradaItem]
ADD CONSTRAINT [FK_DocumentoEntradaItemProduto]
    FOREIGN KEY ([ProdutoId])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentoEntradaItemProduto'
CREATE INDEX [IX_FK_DocumentoEntradaItemProduto]
ON [dbo].[DocumentoEntradaItem]
    ([ProdutoId]);
GO

-- Creating foreign key on [ClienteId] in table 'PedidoVenda'
ALTER TABLE [dbo].[PedidoVenda]
ADD CONSTRAINT [FK_PedidoVendaCliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoVendaCliente'
CREATE INDEX [IX_FK_PedidoVendaCliente]
ON [dbo].[PedidoVenda]
    ([ClienteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------