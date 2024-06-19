CREATE TABLE [dbo].[SPContraModel] (
    [Id]            NVARCHAR (450)  NOT NULL,
    [ContraId]      NVARCHAR (MAX)  NULL,
    [FromPartyId]   NVARCHAR (MAX)  NULL,
    [ToPartyId]     NVARCHAR (MAX)  NULL,
    [FromPartyName] NVARCHAR (MAX)  NULL,
    [ToPartyName]   NVARCHAR (MAX)  NULL,
    [Amount]        DECIMAL (18, 2) NOT NULL,
    [Remarks]       NVARCHAR (MAX)  NULL,
    [UpdatedDate]   DATETIME2 (7)   NULL,
    [UpdatedBy]     NVARCHAR (MAX)  NULL,
    [EntryDate]     DATETIME2 (7)   NULL,
    [Sr]            INT             DEFAULT ((0)) NOT NULL,
    [SrNo]          INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SPContraModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

