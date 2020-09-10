CREATE TABLE [dbo].[Tickets]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UserId] int NULL,
	[CreatedBy] NVARCHAR(MAX) NULL,
	[DateCreated] DATETIME NULL,
	[Title] NVARCHAR(MAX) NOT NULL, 
	[Description] NVARCHAR(MAX) NOT NULL, 
	[Url] NVARCHAR(MAX) NULL, 
	[Platform] NVARCHAR(MAX) NULL, 
	[Os] NVARCHAR(MAX) NULL, 
	[Browser] NVARCHAR(MAX) NULL, 
	[StepsToReproduce] NVARCHAR(MAX) NULL, 
	[ExpectedResult] NVARCHAR(MAX) NULL, 
	[ActualResult] NVARCHAR(MAX) NULL, 
	[Priority] NVARCHAR(50) NOT NULL, 
	[AssignedTo] NVARCHAR(MAX) NOT NULL,
)
