
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2019 12:41:25
-- Generated from EDMX file: C:\ProjetosVS\ComercioManager\CMDataModel\CMEntityDataModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [SubTotal] decimal(19,4)  NOT NULL,
    [Imposto] decimal(19,4)  NOT NULL,
    [Total] decimal(19,4)  NOT NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL,
    [UsuarioIdCaixa] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'PedidoVendaItem'
CREATE TABLE [dbo].[PedidoVendaItem] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantidade] int  NOT NULL,
    [ValorUnitario] decimal(19,4)  NOT NULL,
    [Imposto] decimal(19,4)  NOT NULL,
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
    [Id] nvarchar(128)  NOT NULL,
    [PrimeiroNome] nvarchar(50)  NOT NULL,
    [UltimoNome] nvarchar(50)  NOT NULL,
    [Email] nvarchar(256)  NOT NULL,
    [DataInclusao] datetime  NOT NULL,
    [DataAlteracao] datetime  NOT NULL
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------