CREATE TABLE [dbo].[SPCashBankReport] (
    [Id]        NVARCHAR (MAX)  NULL,
    [Type]      NVARCHAR (MAX)  NULL,
    [ToParty]   NVARCHAR (MAX)  NULL,
    [FromParty] NVARCHAR (MAX)  NULL,
    [CrDrType]  INT             NOT NULL,
    [Debit]     DECIMAL (18, 4) NOT NULL,
    [Credit]    DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [EntryDate] DATETIME2 (7)   NULL,
    [Remarks]   NVARCHAR (MAX)  NULL
);

