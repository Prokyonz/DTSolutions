CREATE TABLE [dbo].[BrokerageMaster] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Sr]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Percentage]  REAL           NOT NULL,
    [IsDelete]    BIT            NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    [CompanyId]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BrokerageMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

