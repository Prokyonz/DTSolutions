CREATE TABLE [dbo].[SPLedgerBalanceReport] (
    [Id]             NVARCHAR (MAX)  NULL,
    [CompanyId]      NVARCHAR (MAX)  NULL,
    [Name]           NVARCHAR (MAX)  NULL,
    [Type]           NVARCHAR (MAX)  NULL,
    [SubType]        NVARCHAR (MAX)  NULL,
    [OpeningBalance] DECIMAL (18, 4) NOT NULL,
    [ClosingBalance] DECIMAL (18, 4) NOT NULL,
    [LedgerId]       NVARCHAR (MAX)  NULL,
    [PartyType]      INT             DEFAULT ((0)) NOT NULL
);

