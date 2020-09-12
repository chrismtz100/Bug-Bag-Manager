﻿/*
Deployment script for BugBagDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BugBagDB"
:setvar DefaultFilePrefix "BugBagDB"
:setvar DefaultDataPath "C:\Users\Christian\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Christian\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column DateCreated on table [dbo].[Tickets] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The type for column DateCreated in table [dbo].[Tickets] is currently  INT NULL but is being changed to  DATETIME2 (7) NOT NULL. There is no implicit or explicit conversion.
*/

IF EXISTS (select top 1 1 from [dbo].[Tickets])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[Tickets]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Tickets] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [UserId]           INT            NULL,
    [CreatedBy]        NVARCHAR (MAX) NULL,
    [DateCreated]      DATETIME2 (7)  DEFAULT GetDate() NOT NULL,
    [Title]            NVARCHAR (MAX) NOT NULL,
    [Description]      NVARCHAR (MAX) NOT NULL,
    [Url]              NVARCHAR (MAX) NULL,
    [Platform]         NVARCHAR (MAX) NULL,
    [Os]               NVARCHAR (MAX) NULL,
    [Browser]          NVARCHAR (MAX) NULL,
    [StepsToReproduce] NVARCHAR (MAX) NULL,
    [ExpectedResult]   NVARCHAR (MAX) NULL,
    [ActualResult]     NVARCHAR (MAX) NULL,
    [Priority]         NVARCHAR (50)  NOT NULL,
    [AssignedTo]       NVARCHAR (MAX) NOT NULL,
    [Severity]         NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Tickets])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tickets] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Tickets] ([Id], [UserId], [CreatedBy], [DateCreated], [Title], [Description], [Url], [Platform], [Os], [Browser], [StepsToReproduce], [ExpectedResult], [ActualResult], [Priority], [AssignedTo], [Severity])
        SELECT   [Id],
                 [UserId],
                 [CreatedBy],
                 [DateCreated],
                 [Title],
                 [Description],
                 [Url],
                 [Platform],
                 [Os],
                 [Browser],
                 [StepsToReproduce],
                 [ExpectedResult],
                 [ActualResult],
                 [Priority],
                 [AssignedTo],
                 [Severity]
        FROM     [dbo].[Tickets]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tickets] OFF;
    END

DROP TABLE [dbo].[Tickets];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Tickets]', N'Tickets';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO