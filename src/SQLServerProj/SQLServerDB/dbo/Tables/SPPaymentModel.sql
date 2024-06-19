CREATE TABLE [dbo].[SPPaymentModel] (
    [Id]           NVARCHAR (450)  NOT NULL,
    [GroupId]      NVARCHAR (MAX)  NULL,
    [FromPartyId]  NVARCHAR (MAX)  NULL,
    [ToPartyId]    NVARCHAR (MAX)  NULL,
    [FromName]     NVARCHAR (MAX)  NULL,
    [ToName]       NVARCHAR (MAX)  NULL,
    [Amount]       DECIMAL (18, 2) NOT NULL,
    [ChequeNo]     NVARCHAR (MAX)  NULL,
    [ChequeDate]   DATETIME2 (7)   NULL,
    [Remarks]      NVARCHAR (MAX)  NULL,
    [EntryDate]    DATETIME2 (7)   NULL,
    [ApprovalType] NVARCHAR (MAX)  NULL,
    [SrNo]         INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SPPaymentModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

