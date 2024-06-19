CREATE TABLE [dbo].[SlipTransferEntry] (
    [Id]                    NVARCHAR (450)  NOT NULL,
    [Sr]                    INT             IDENTITY (1, 1) NOT NULL,
    [SlipTransferEntryDate] DATETIME2 (7)   NOT NULL,
    [Amount]                DECIMAL (18, 4) NOT NULL,
    [CreatedDate]           DATETIME2 (7)   NOT NULL,
    [UpdatedDate]           DATETIME2 (7)   NULL,
    [CreatedBy]             NVARCHAR (MAX)  NULL,
    [UpdatedBy]             NVARCHAR (MAX)  NULL,
    [Message]               NVARCHAR (MAX)  NULL,
    [ApprovalType]          INT             NOT NULL,
    [Party]                 NVARCHAR (MAX)  NULL,
    [PurchaseSaleId]        NVARCHAR (MAX)  NULL,
    [SlipType]              INT             DEFAULT ((0)) NOT NULL,
    [BranchId]              NVARCHAR (MAX)  NULL,
    [FinancialYearId]       NVARCHAR (MAX)  NULL,
    [SrNo]                  INT             DEFAULT ((0)) NOT NULL,
    [Days]                  INT             DEFAULT ((0)) NOT NULL,
    [Percentage]            DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [Total]                 DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    CONSTRAINT [PK_SlipTransferEntry] PRIMARY KEY CLUSTERED ([Id] ASC)
);

