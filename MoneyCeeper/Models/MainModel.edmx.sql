
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2020 19:47:29
-- Generated from EDMX file: H:\Андрей и Учеба в БГТУ\Курсовые\СТПМС\MoneyCeeper\MoneyCeeper\Models\MainModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MoneyCeeperDB];
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

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Login] nvarchar(32)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CostSet'
CREATE TABLE [dbo].[CostSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] float  NOT NULL,
    [Date_Time] datetime  NOT NULL,
    [Comment] nvarchar(300)  NOT NULL,
    [Description] nvarchar(300)  NULL,
    [Category] int  NOT NULL,
    [UserLogin] nvarchar(32)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Login] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Login] ASC);
GO

-- Creating primary key on [Id] in table 'CostSet'
ALTER TABLE [dbo].[CostSet]
ADD CONSTRAINT [PK_CostSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserLogin] in table 'CostSet'
ALTER TABLE [dbo].[CostSet]
ADD CONSTRAINT [FK_UserCost]
    FOREIGN KEY ([UserLogin])
    REFERENCES [dbo].[UserSet]
        ([Login])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCost'
CREATE INDEX [IX_FK_UserCost]
ON [dbo].[CostSet]
    ([UserLogin]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------