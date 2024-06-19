CREATE TABLE [dbo].[LedgerBalanceManager] (
    [Id]              NVARCHAR (450)  NOT NULL,
    [Sr]              INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [LedgerId]        NVARCHAR (MAX)  NULL,
    [Balance]         DECIMAL (18, 2) NOT NULL,
    [TypeOfBalance]   INT             NOT NULL,
    [CreatedDate]     DATETIME2 (7)   NOT NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [UpdatedBy]       NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_LedgerBalanceManager] PRIMARY KEY CLUSTERED ([Id] ASC)
);

