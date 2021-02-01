
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2021 18:48:47
-- Generated from EDMX file: C:\Users\a.simsek\Desktop\Dev Projects\KuryeTakip\KuryeTakip\DataAccessLayer\DataBaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KuryeTakip];
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

-- Creating table 'UrunSet'
CREATE TABLE [dbo].[UrunSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Kurye_Id] int  NOT NULL
);
GO

-- Creating table 'KuryeSet'
CREATE TABLE [dbo].[KuryeSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RestoranSet'
CREATE TABLE [dbo].[RestoranSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Urun_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UrunSet'
ALTER TABLE [dbo].[UrunSet]
ADD CONSTRAINT [PK_UrunSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KuryeSet'
ALTER TABLE [dbo].[KuryeSet]
ADD CONSTRAINT [PK_KuryeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RestoranSet'
ALTER TABLE [dbo].[RestoranSet]
ADD CONSTRAINT [PK_RestoranSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kurye_Id] in table 'UrunSet'
ALTER TABLE [dbo].[UrunSet]
ADD CONSTRAINT [FK_UrunKurye]
    FOREIGN KEY ([Kurye_Id])
    REFERENCES [dbo].[KuryeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UrunKurye'
CREATE INDEX [IX_FK_UrunKurye]
ON [dbo].[UrunSet]
    ([Kurye_Id]);
GO

-- Creating foreign key on [Urun_Id] in table 'RestoranSet'
ALTER TABLE [dbo].[RestoranSet]
ADD CONSTRAINT [FK_UrunRestoran]
    FOREIGN KEY ([Urun_Id])
    REFERENCES [dbo].[UrunSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UrunRestoran'
CREATE INDEX [IX_FK_UrunRestoran]
ON [dbo].[RestoranSet]
    ([Urun_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------