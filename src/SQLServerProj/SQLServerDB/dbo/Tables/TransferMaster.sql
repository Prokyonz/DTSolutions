CREATE TABLE [dbo].[TransferMaster] (
    [Id]              NVARCHAR (450)  NOT NULL,
    [Sr]              INT             IDENTITY (1, 1) NOT NULL,
    [JangadNo]        INT             NOT NULL,
    [Date]            NVARCHAR (MAX)  NULL,
    [Time]            NVARCHAR (MAX)  NULL,
    [TRansferById]    NVARCHAR (MAX)  NULL,
    [Remark]          NVARCHAR (MAX)  NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [Image1]          VARBINARY (MAX) NULL,
    [Image2]          VARBINARY (MAX) NULL,
    [Image3]          VARBINARY (MAX) NULL,
    [IsDelete]        BIT             NOT NULL,
    [CreatedDate]     DATETIME2 (7)   NOT NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [UpdatedBy]       NVARCHAR (MAX)  NULL,
    [CharniSizeId]    NVARCHAR (MAX)  NULL,
    [Message]         NVARCHAR (MAX)  NULL,
    [ApprovalType]    INT             NOT NULL,
    CONSTRAINT [PK_TransferMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

