CREATE TABLE [dbo].[CurrencyMaster] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [Sr]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NULL,
    [ShortName]   NVARCHAR (MAX)  NULL,
    [Value]       DECIMAL (18, 4) NOT NULL,
    [IsDelete]    BIT             NOT NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [CreatedBy]   NVARCHAR (MAX)  NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [UpdatedBy]   NVARCHAR (MAX)  NULL,
    [CompanyId]   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_CurrencyMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

