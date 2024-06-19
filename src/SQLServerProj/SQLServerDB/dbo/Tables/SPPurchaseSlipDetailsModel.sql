CREATE TABLE [dbo].[SPPurchaseSlipDetailsModel] (
    [Id]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [SlipNo]          BIGINT         NOT NULL,
    [Date]            NVARCHAR (MAX) NULL,
    [PartyId]         NVARCHAR (MAX) NULL,
    [Party]           NVARCHAR (MAX) NULL,
    [BrokerageId]     NVARCHAR (MAX) NULL,
    [Broker]          NVARCHAR (MAX) NULL,
    [FinancialYearId] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SPPurchaseSlipDetailsModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

