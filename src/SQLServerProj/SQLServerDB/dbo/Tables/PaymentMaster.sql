CREATE TABLE [dbo].[PaymentMaster] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [Sr]          INT             IDENTITY (1, 1) NOT NULL,
    [GroupId]     NVARCHAR (450)  NULL,
    [FromPartyId] NVARCHAR (MAX)  NULL,
    [Amount]      DECIMAL (18, 2) NOT NULL,
    [ChequeNo]    NVARCHAR (MAX)  NULL,
    [ChequeDate]  DATETIME2 (7)   NULL,
    [Remarks]     NVARCHAR (MAX)  NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [CreatedBy]   NVARCHAR (MAX)  NULL,
    [UpdatedBy]   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_PaymentMaster] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaymentMaster_GroupPaymentMaster_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[GroupPaymentMaster] ([Id])
);

