
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2021 15:31:14
-- Generated from EDMX file: C:\Users\a.simsek\Desktop\Dev Projects\KuryeTakip\KuryeTakip\DataAccessLayer\KuryeTakipDatabase.edmx
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

IF OBJECT_ID(N'[dbo].[KuryeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KuryeSet];
GO
IF OBJECT_ID(N'[dbo].[RestoranSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RestoranSet];
GO
IF OBJECT_ID(N'[dbo].[SiparisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiparisSet];
GO
IF OBJECT_ID(N'[dbo].[BolgeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BolgeSet];
GO
IF OBJECT_ID(N'[dbo].[AyarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AyarSet];
GO
IF OBJECT_ID(N'[dbo].[OdemeYontemiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OdemeYontemiSet];
GO

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
    [Isim] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SiparisSet'
CREATE TABLE [dbo].[SiparisSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HazirlanmaSuresi] nvarchar(max)  NOT NULL,
    [TeslimatSuresi] nvarchar(max)  NOT NULL,
    [KuryeIsim] nvarchar(max)  NOT NULL,
    [OdemeYontem] nvarchar(max)  NOT NULL,
    [RestoranIsim] nvarchar(max)  NOT NULL,
    [BolgeIsim] nvarchar(max)  NOT NULL,
    [Tarih] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BolgeSet'
CREATE TABLE [dbo].[BolgeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Isim] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AyarSet'
CREATE TABLE [dbo].[AyarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SMSUserCode] nvarchar(max)  NULL,
    [SMSPassword] nvarchar(max)  NULL,
    [SMSMessageHeader] nvarchar(max)  NULL,
    [SMSMessageTemplate] nvarchar(max)  NULL
);
GO

-- Creating table 'OdemeYontemiSet'
CREATE TABLE [dbo].[OdemeYontemiSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [YontemIsim] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KullaniciSet'
CREATE TABLE [dbo].[KullaniciSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'BolgeSet'
ALTER TABLE [dbo].[BolgeSet]
ADD CONSTRAINT [PK_BolgeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AyarSet'
ALTER TABLE [dbo].[AyarSet]
ADD CONSTRAINT [PK_AyarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OdemeYontemiSet'
ALTER TABLE [dbo].[OdemeYontemiSet]
ADD CONSTRAINT [PK_OdemeYontemiSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KullaniciSet'
ALTER TABLE [dbo].[KullaniciSet]
ADD CONSTRAINT [PK_KullaniciSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------