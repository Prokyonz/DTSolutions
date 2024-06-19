CREATE TABLE [dbo].[PriceMasterMobile] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [Sr]          INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]   NVARCHAR (MAX)  NULL,
    [CategoryId]  NVARCHAR (MAX)  NULL,
    [Price]       DECIMAL (18, 4) NOT NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [CreatedBy]   NVARCHAR (MAX)  NULL,
    [UpdatedBy]   NVARCHAR (MAX)  NULL,
    [NumberName]  NVARCHAR (MAX)  NULL,
    [SizeName]    NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_PriceMasterMobile] PRIMARY KEY CLUSTERED ([Id] ASC)
);

