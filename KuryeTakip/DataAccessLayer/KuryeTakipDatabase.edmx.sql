
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2021 20:35:04
-- Generated from EDMX file: C:\Users\a.simsek\Desktop\Dev Projects\KuryeTakip\KuryeTakip\KuryeTakipDatabase.edmx
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

-- Creating table 'KuryeSet'
CREATE TABLE [dbo].[KuryeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Isim] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RestoranSet'
CREATE TABLE [dbo].[RestoranSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Isim] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SiparisSet'
CREATE TABLE [dbo].[SiparisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HazirlanmaSuresi] nvarchar(max)  NOT NULL,
    [TeslimatSuresi] nvarchar(max)  NOT NULL,
    [Kurye_Id] int  NOT NULL,
    [Restoran_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

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

-- Creating primary key on [Id] in table 'SiparisSet'
ALTER TABLE [dbo].[SiparisSet]
ADD CONSTRAINT [PK_SiparisSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kurye_Id] in table 'SiparisSet'
ALTER TABLE [dbo].[SiparisSet]
ADD CONSTRAINT [FK_SiparisKurye]
    FOREIGN KEY ([Kurye_Id])
    REFERENCES [dbo].[KuryeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SiparisKurye'
CREATE INDEX [IX_FK_SiparisKurye]
ON [dbo].[SiparisSet]
    ([Kurye_Id]);
GO

-- Creating foreign key on [Restoran_Id] in table 'SiparisSet'
ALTER TABLE [dbo].[SiparisSet]
ADD CONSTRAINT [FK_SiparisRestoran]
    FOREIGN KEY ([Restoran_Id])
    REFERENCES [dbo].[RestoranSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SiparisRestoran'
CREATE INDEX [IX_FK_SiparisRestoran]
ON [dbo].[SiparisSet]
    ([Restoran_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------