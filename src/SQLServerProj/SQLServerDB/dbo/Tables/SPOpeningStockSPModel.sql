CREATE TABLE [dbo].[SPOpeningStockSPModel] (
    [Id]              NVARCHAR (450)  NOT NULL,
    [SrNo]            INT             NOT NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [KapanName]       NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [SizeName]        NVARCHAR (MAX)  NULL,
    [NumberId]        NVARCHAR (MAX)  NULL,
    [NumberName]      NVARCHAR (MAX)  NULL,
    [TotalCts]        DECIMAL (18, 4) NOT NULL,
    [Rate]            DECIMAL (18, 4) NOT NULL,
    [Amount]          DECIMAL (18, 4) NOT NULL,
    [Remarks]         NVARCHAR (MAX)  NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [BranchId]        NVARCHAR (MAX)  NULL,
    [BranchName]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_SPOpeningStockSPModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

