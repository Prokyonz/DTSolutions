CREATE TABLE [dbo].[SPMixedReportModel] (
    [Id]              NVARCHAR (450) NOT NULL,
    [CompanyId]       NVARCHAR (MAX) NULL,
    [FinancialYearId] NVARCHAR (MAX) NULL,
    [FromPartyId]     NVARCHAR (MAX) NULL,
    [ToPartyId]       NVARCHAR (MAX) NULL,
    [FromName]        NVARCHAR (MAX) NULL,
    [ToName]          NVARCHAR (MAX) NULL,
    [Credit]          FLOAT (53)     NULL,
    [Debit]           FLOAT (53)     NULL,
    [CreatedDate]     DATETIME2 (7)  NULL,
    [TrType]          NVARCHAR (MAX) NULL,
    [EntryDate]       DATETIME2 (7)  NULL,
    [Remarks]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SPMixedReportModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

