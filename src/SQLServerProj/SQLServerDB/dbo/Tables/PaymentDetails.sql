CREATE TABLE [dbo].[PaymentDetails] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [Sr]          INT             IDENTITY (1, 1) NOT NULL,
    [PaymentId]   NVARCHAR (450)  NULL,
    [GroupId]     NVARCHAR (450)  NULL,
    [PurchaseId]  NVARCHAR (MAX)  NULL,
    [SlipNo]      NVARCHAR (MAX)  NULL,
    [Amount]      DECIMAL (18, 2) NOT NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [UpdatedDate] DATETIME2 (7)   NULL,
    [CreatedBy]   NVARCHAR (MAX)  NULL,
    [UpdatedBy]   NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_PaymentDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PaymentDetails_GroupPaymentMaster_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[GroupPaymentMaster] ([Id]),
    CONSTRAINT [FK_PaymentDetails_PaymentMaster_PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [dbo].[PaymentMaster] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PaymentDetails_GroupId]
    ON [dbo].[PaymentDetails]([GroupId] ASC);

