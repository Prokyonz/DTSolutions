CREATE TABLE [dbo].[tblSlipPrint] (
    [SlipNo]                 BIGINT          NULL,
    [Date]                   VARCHAR (30)    NULL,
    [PartyId]                NVARCHAR (MAX)  NULL,
    [Party]                  NVARCHAR (MAX)  NULL,
    [BrokerageId]            NVARCHAR (MAX)  NULL,
    [Broker]                 NVARCHAR (MAX)  NULL,
    [Weight]                 DECIMAL (19, 4) NULL,
    [CVDWeight]              DECIMAL (18, 4) NOT NULL,
    [RejectedWeight]         DECIMAL (18, 4) NOT NULL,
    [LessWeight]             DECIMAL (18, 4) NOT NULL,
    [NetWeight]              DECIMAL (18, 4) NOT NULL,
    [CRate]                  FLOAT (53)      NOT NULL,
    [LessDiscountPercentage] DECIMAL (18, 4) NOT NULL,
    [Rate]                   FLOAT (53)      NULL,
    [Disc]                   FLOAT (53)      NULL,
    [CVDCharge]              FLOAT (53)      NULL,
    [DueDays]                INT             NULL,
    [PaymentDays]            INT             NULL,
    [Total]                  FLOAT (53)      NULL,
    [Final]                  FLOAT (53)      NULL
);

