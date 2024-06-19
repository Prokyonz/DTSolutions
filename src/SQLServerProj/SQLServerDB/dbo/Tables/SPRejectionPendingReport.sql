CREATE TABLE [dbo].[SPRejectionPendingReport] (
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [PartyName]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [SlipNo]          NVARCHAR (MAX)  NULL,
    [ProcessType]     NVARCHAR (MAX)  NULL,
    [RejectionWeight] DECIMAL (18, 4) NOT NULL
);

