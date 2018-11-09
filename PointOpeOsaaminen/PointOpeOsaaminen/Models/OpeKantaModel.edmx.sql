
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2018 09:44:01
-- Generated from EDMX file: D:\Point College\Scrum\PointOpeOsaaminen\PointOpeOsaaminen\PointOpeOsaaminen\Models\OpeKantaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OpeOsaamisKanta];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Osaamiset__Opett__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osaamiset] DROP CONSTRAINT [FK__Osaamiset__Opett__5441852A];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Opettaja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opettaja];
GO
IF OBJECT_ID(N'[dbo].[Osaamiset]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osaamiset];
GO
IF OBJECT_ID(N'[OpeOsaamisKantaModelStoreContainer].[database_firewall_rules]', 'U') IS NOT NULL
    DROP TABLE [OpeOsaamisKantaModelStoreContainer].[database_firewall_rules];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Opettaja'
CREATE TABLE [dbo].[Opettaja] (
    [OpettajaID] int IDENTITY(1,1) NOT NULL,
    [Etunimi] nvarchar(50)  NULL,
    [Sukunimi] nvarchar(50)  NULL,
    [Sähköposti] nvarchar(100)  NULL,
    [Henkilönumero] nvarchar(10)  NULL,
    [Yksikkö] nvarchar(10)  NULL,
    [Toimenkuva] nvarchar(50)  NULL
);
GO

-- Creating table 'Osaamiset'
CREATE TABLE [dbo].[Osaamiset] (
    [OsaamisID] int IDENTITY(1,1) NOT NULL,
    [Osaaminen] nvarchar(50)  NULL,
    [OpettamisenHalukkuus] bit  NOT NULL,
    [Kuvaus] nvarchar(200)  NULL,
    [OpettajaID] int  NULL
);
GO

-- Creating table 'database_firewall_rules'
CREATE TABLE [dbo].[database_firewall_rules] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(128)  NOT NULL,
    [start_ip_address] varchar(45)  NOT NULL,
    [end_ip_address] varchar(45)  NOT NULL,
    [create_date] datetime  NOT NULL,
    [modify_date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OpettajaID] in table 'Opettaja'
ALTER TABLE [dbo].[Opettaja]
ADD CONSTRAINT [PK_Opettaja]
    PRIMARY KEY CLUSTERED ([OpettajaID] ASC);
GO

-- Creating primary key on [OsaamisID] in table 'Osaamiset'
ALTER TABLE [dbo].[Osaamiset]
ADD CONSTRAINT [PK_Osaamiset]
    PRIMARY KEY CLUSTERED ([OsaamisID] ASC);
GO

-- Creating primary key on [id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] in table 'database_firewall_rules'
ALTER TABLE [dbo].[database_firewall_rules]
ADD CONSTRAINT [PK_database_firewall_rules]
    PRIMARY KEY CLUSTERED ([id], [name], [start_ip_address], [end_ip_address], [create_date], [modify_date] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OpettajaID] in table 'Osaamiset'
ALTER TABLE [dbo].[Osaamiset]
ADD CONSTRAINT [FK__Osaamiset__Opett__5441852A]
    FOREIGN KEY ([OpettajaID])
    REFERENCES [dbo].[Opettaja]
        ([OpettajaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Osaamiset__Opett__5441852A'
CREATE INDEX [IX_FK__Osaamiset__Opett__5441852A]
ON [dbo].[Osaamiset]
    ([OpettajaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------