CREATE TABLE [dbo].[SPBoilProcessSend] (
    [Id]                       NVARCHAR (MAX)  NULL,
    [SlipNo]                   BIGINT          NOT NULL,
    [KapanId]                  NVARCHAR (MAX)  NULL,
    [Kapan]                    NVARCHAR (MAX)  NULL,
    [PurchaseDetailsId]        NVARCHAR (MAX)  NULL,
    [ShapeId]                  NVARCHAR (MAX)  NULL,
    [Shape]                    NVARCHAR (MAX)  NULL,
    [SizeId]                   NVARCHAR (MAX)  NULL,
    [Size]                     NVARCHAR (MAX)  NULL,
    [PurityId]                 NVARCHAR (MAX)  NULL,
    [Purity]                   NVARCHAR (MAX)  NULL,
    [FinancialYearId]          NVARCHAR (MAX)  NULL,
    [NetWeight]                DECIMAL (18, 2) NOT NULL,
    [TIPWeight]                DECIMAL (18, 2) NOT NULL,
    [LessWeight]               DECIMAL (18, 2) NOT NULL,
    [Weight]                   DECIMAL (18, 2) NOT NULL,
    [RejectedWeight]           DECIMAL (18, 2) NOT NULL,
    [AvailableWeight]          DECIMAL (18, 2) NOT NULL,
    [StockId]                  NVARCHAR (MAX)  NULL,
    [AccountToAssortDetailsId] NVARCHAR (MAX)  NULL
);

