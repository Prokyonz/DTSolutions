CREATE TABLE [dbo].[SPExpenseModel] (
    [Id]            NVARCHAR (MAX) NULL,
    [Sr]            INT            NOT NULL,
    [SrNo]          INT            NOT NULL,
    [CompanyId]     NVARCHAR (MAX) NULL,
    [BranchId]      NVARCHAR (MAX) NULL,
    [BranchName]    NVARCHAR (MAX) NULL,
    [PartyId]       NVARCHAR (MAX) NULL,
    [Amount]        FLOAT (53)     NOT NULL,
    [Remarks]       NVARCHAR (MAX) NULL,
    [UpdatedDate]   DATETIME2 (7)  NULL,
    [UpdatedBy]     NVARCHAR (MAX) NULL,
    [EntryDate]     DATETIME2 (7)  NULL,
    [CrDrType]      INT            DEFAULT ((0)) NOT NULL,
    [FromPartyName] NVARCHAR (MAX) NULL,
    [ToPartyName]   NVARCHAR (MAX) NULL
);

