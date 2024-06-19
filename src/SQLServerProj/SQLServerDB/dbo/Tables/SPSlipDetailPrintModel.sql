CREATE TABLE [dbo].[SPSlipDetailPrintModel] (
    [Id]                     BIGINT          IDENTITY (1, 1) NOT NULL,
    [SlipNo]                 BIGINT          NOT NULL,
    [Date]                   NVARCHAR (MAX)  NULL,
    [PartyId]                NVARCHAR (MAX)  NULL,
    [Party]                  NVARCHAR (MAX)  NULL,
    [BrokerageId]            NVARCHAR (MAX)  NULL,
    [Broker]                 NVARCHAR (MAX)  NULL,
    [Weight]                 DECIMAL (18, 2) NOT NULL,
    [CVDWeight]              DECIMAL (18, 2) NOT NULL,
    [LessDiscountPercentage] DECIMAL (18, 2) NOT NULL,
    [RejectedWeight]         DECIMAL (18, 2) NOT NULL,
    [LessWeight]             DECIMAL (18, 2) NOT NULL,
    [NetWeight]              DECIMAL (18, 2) NOT NULL,
    [CRate]                  DECIMAL (18, 2) NOT NULL,
    [Disc]                   DECIMAL (18, 2) NOT NULL,
    [CVDCharge]              DECIMAL (18, 2) NOT NULL,
    [DueDays]                INT             NOT NULL,
    [PaymentDays]            INT             NOT NULL,
    [Total]                  DECIMAL (18, 2) NOT NULL,
    [Final]                  DECIMAL (18, 2) NOT NULL
);

