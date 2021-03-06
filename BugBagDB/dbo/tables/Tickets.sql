﻿CREATE TABLE [dbo].[Tickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UserId] int NOT NULL,
	[CreatedBy] NVARCHAR(MAX) NULL,
	[DateCreated] DATETIME NULL,
	[Title] NVARCHAR(MAX) NOT NULL, 
	[Description] NVARCHAR(MAX) NOT NULL, 
	[Url] NVARCHAR(MAX) NULL, 
	[Type] NVARCHAR(MAX) NULL, 
	[Os] NVARCHAR(MAX) NULL, 
	[Browser] NVARCHAR(MAX) NULL, 
	[StepsToReproduce] NVARCHAR(MAX) NULL, 
	[ExpectedResult] NVARCHAR(MAX) NULL, 
	[ActualResult] NVARCHAR(MAX) NULL, 
	[Priority] NVARCHAR(50) NULL, 
	[AssignedTo] NVARCHAR(MAX) NULL, 
	[TicketStatus] BIT NULL,
)
