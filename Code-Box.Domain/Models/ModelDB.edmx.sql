
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2020 18:08:04
-- Generated from EDMX file: E:\Code-Box\Code-Box.Domain\Models\ModelDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Code-BoxDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TopicDetails_tb_Courses_tb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicDetails_tb] DROP CONSTRAINT [FK_TopicDetails_tb_Courses_tb];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicDetails_tb_Vertical_Nav_tb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicDetails_tb] DROP CONSTRAINT [FK_TopicDetails_tb_Vertical_Nav_tb];
GO
IF OBJECT_ID(N'[dbo].[FK_Vertical_Nav_tb_Courses_tb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vertical_Nav_tb] DROP CONSTRAINT [FK_Vertical_Nav_tb_Courses_tb];
GO
IF OBJECT_ID(N'[dbo].[FK_vertical_tab_list_tb_Courses_tb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[vertical_tab_list_tb] DROP CONSTRAINT [FK_vertical_tab_list_tb_Courses_tb];
GO
IF OBJECT_ID(N'[dbo].[FK_vertical_tab_list_tb_Vertical_Nav_tb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[vertical_tab_list_tb] DROP CONSTRAINT [FK_vertical_tab_list_tb_Vertical_Nav_tb];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Courses_tb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses_tb];
GO
IF OBJECT_ID(N'[dbo].[SideNavigationMenuAdmin_tb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SideNavigationMenuAdmin_tb];
GO
IF OBJECT_ID(N'[dbo].[TopicDetails_tb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicDetails_tb];
GO
IF OBJECT_ID(N'[dbo].[Vertical_Nav_tb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vertical_Nav_tb];
GO
IF OBJECT_ID(N'[dbo].[vertical_tab_list_tb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[vertical_tab_list_tb];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Courses_tb'
CREATE TABLE [dbo].[Courses_tb] (
    [CoursesID] int IDENTITY(1,1) NOT NULL,
    [CourseName] nvarchar(50)  NULL,
    [Active] bit  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Vertical_Nav_tb'
CREATE TABLE [dbo].[Vertical_Nav_tb] (
    [id] int IDENTITY(1,1) NOT NULL,
    [navName] nvarchar(50)  NULL,
    [Active] bit  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [CourseID] int  NULL
);
GO

-- Creating table 'vertical_tab_list_tb'
CREATE TABLE [dbo].[vertical_tab_list_tb] (
    [CourseID] int  NULL,
    [TopicID] int  NULL,
    [Active] bit  NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'TopicDetails_tb'
CREATE TABLE [dbo].[TopicDetails_tb] (
    [TopicDetailsId] int IDENTITY(1,1) NOT NULL,
    [TopicId] int  NULL,
    [TopicName] nvarchar(50)  NULL,
    [TechnologyType] nvarchar(50)  NULL,
    [PostedBy] nvarchar(50)  NULL,
    [CreatedDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [Active] bit  NULL,
    [TopicDetails] varchar(max)  NULL,
    [CourseID] int  NULL
);
GO

-- Creating table 'SideNavigationMenuAdmin_tb'
CREATE TABLE [dbo].[SideNavigationMenuAdmin_tb] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Active] bit  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CoursesID] in table 'Courses_tb'
ALTER TABLE [dbo].[Courses_tb]
ADD CONSTRAINT [PK_Courses_tb]
    PRIMARY KEY CLUSTERED ([CoursesID] ASC);
GO

-- Creating primary key on [id] in table 'Vertical_Nav_tb'
ALTER TABLE [dbo].[Vertical_Nav_tb]
ADD CONSTRAINT [PK_Vertical_Nav_tb]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'vertical_tab_list_tb'
ALTER TABLE [dbo].[vertical_tab_list_tb]
ADD CONSTRAINT [PK_vertical_tab_list_tb]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [TopicDetailsId] in table 'TopicDetails_tb'
ALTER TABLE [dbo].[TopicDetails_tb]
ADD CONSTRAINT [PK_TopicDetails_tb]
    PRIMARY KEY CLUSTERED ([TopicDetailsId] ASC);
GO

-- Creating primary key on [Id] in table 'SideNavigationMenuAdmin_tb'
ALTER TABLE [dbo].[SideNavigationMenuAdmin_tb]
ADD CONSTRAINT [PK_SideNavigationMenuAdmin_tb]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourseID] in table 'vertical_tab_list_tb'
ALTER TABLE [dbo].[vertical_tab_list_tb]
ADD CONSTRAINT [FK_vertical_tab_list_tb_Courses_tb]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses_tb]
        ([CoursesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_vertical_tab_list_tb_Courses_tb'
CREATE INDEX [IX_FK_vertical_tab_list_tb_Courses_tb]
ON [dbo].[vertical_tab_list_tb]
    ([CourseID]);
GO

-- Creating foreign key on [TopicID] in table 'vertical_tab_list_tb'
ALTER TABLE [dbo].[vertical_tab_list_tb]
ADD CONSTRAINT [FK_vertical_tab_list_tb_Vertical_Nav_tb]
    FOREIGN KEY ([TopicID])
    REFERENCES [dbo].[Vertical_Nav_tb]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_vertical_tab_list_tb_Vertical_Nav_tb'
CREATE INDEX [IX_FK_vertical_tab_list_tb_Vertical_Nav_tb]
ON [dbo].[vertical_tab_list_tb]
    ([TopicID]);
GO

-- Creating foreign key on [CourseID] in table 'Vertical_Nav_tb'
ALTER TABLE [dbo].[Vertical_Nav_tb]
ADD CONSTRAINT [FK_Vertical_Nav_tb_Courses_tb]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses_tb]
        ([CoursesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vertical_Nav_tb_Courses_tb'
CREATE INDEX [IX_FK_Vertical_Nav_tb_Courses_tb]
ON [dbo].[Vertical_Nav_tb]
    ([CourseID]);
GO

-- Creating foreign key on [CourseID] in table 'TopicDetails_tb'
ALTER TABLE [dbo].[TopicDetails_tb]
ADD CONSTRAINT [FK_TopicDetails_tb_Courses_tb]
    FOREIGN KEY ([CourseID])
    REFERENCES [dbo].[Courses_tb]
        ([CoursesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicDetails_tb_Courses_tb'
CREATE INDEX [IX_FK_TopicDetails_tb_Courses_tb]
ON [dbo].[TopicDetails_tb]
    ([CourseID]);
GO

-- Creating foreign key on [TopicId] in table 'TopicDetails_tb'
ALTER TABLE [dbo].[TopicDetails_tb]
ADD CONSTRAINT [FK_TopicDetails_tb_Vertical_Nav_tb]
    FOREIGN KEY ([TopicId])
    REFERENCES [dbo].[Vertical_Nav_tb]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicDetails_tb_Vertical_Nav_tb'
CREATE INDEX [IX_FK_TopicDetails_tb_Vertical_Nav_tb]
ON [dbo].[TopicDetails_tb]
    ([TopicId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------