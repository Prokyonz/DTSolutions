CREATE TABLE [dbo].[PriceMaster] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [Sr]          INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]   NVARCHAR (MAX)  NULL,
    [CategoryId]  NVARCHAR (MAX)  NULL,
    [SizeId]      NVARCHAR (MAX)  NULL,
    [NumberId]    NVARCHAR (MAX)  NULL,
    [Price]       DECIMAL (18, 4) NOT NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [CreatedBy]   NVARCHAR (MAX)  NULL,
    [UpdatedBy]   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_PriceMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

