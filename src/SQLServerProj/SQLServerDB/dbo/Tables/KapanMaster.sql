CREATE TABLE [dbo].[KapanMaster] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [Sr]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NULL,
    [Details]     NVARCHAR (MAX)  NULL,
    [CaratLimit]  DECIMAL (18, 4) NOT NULL,
    [IsStatus]    BIT             NOT NULL,
    [IsDelete]    BIT             NOT NULL,
    [StartDate]   DATETIME2 (7)   NOT NULL,
    [EndDate]     DATETIME2 (7)   NOT NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [CreatedBy]   NVARCHAR (MAX)  NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [UpdatedBy]   NVARCHAR (MAX)  NULL,
    [CompanyId]   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_KapanMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

