CREATE TABLE [dbo].[SPLedgerChildReport] (
    [EntryType]     NVARCHAR (MAX)  NULL,
    [FromPartyId]   NVARCHAR (MAX)  NULL,
    [FromPartyName] NVARCHAR (MAX)  NULL,
    [ToPartyId]     NVARCHAR (MAX)  NULL,
    [ToPartyName]   NVARCHAR (MAX)  NULL,
    [Debit]         DECIMAL (18, 4) NOT NULL,
    [Credit]        DECIMAL (18, 4) NOT NULL,
    [Date]          DATETIME2 (7)   NULL,
    [Remarks]       NVARCHAR (MAX)  NULL,
    [SlipNo]        NVARCHAR (MAX)  NULL
);

