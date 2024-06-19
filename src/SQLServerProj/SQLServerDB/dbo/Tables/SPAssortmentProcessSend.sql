CREATE TABLE [dbo].[SPAssortmentProcessSend] (
    [Id]                NVARCHAR (MAX)  NULL,
    [SlipNo]            NVARCHAR (MAX)  NULL,
    [PurchaseDetailsId] NVARCHAR (MAX)  NULL,
    [KapanId]           NVARCHAR (MAX)  NULL,
    [Kapan]             NVARCHAR (MAX)  NULL,
    [ShapeId]           NVARCHAR (MAX)  NULL,
    [Shape]             NVARCHAR (MAX)  NULL,
    [SizeId]            NVARCHAR (MAX)  NULL,
    [Size]              NVARCHAR (MAX)  NULL,
    [PurityId]          NVARCHAR (MAX)  NULL,
    [Purity]            NVARCHAR (MAX)  NULL,
    [FinancialYearId]   NVARCHAR (MAX)  NULL,
    [NetWeight]         DECIMAL (18, 2) NOT NULL,
    [TIPWeight]         DECIMAL (18, 2) NOT NULL,
    [LessWeight]        DECIMAL (18, 2) NOT NULL,
    [Weight]            DECIMAL (18, 2) NOT NULL,
    [RejectedWeight]    DECIMAL (18, 2) NOT NULL,
    [AvailableWeight]   DECIMAL (18, 2) NOT NULL,
    [PurchaseMasterId]  NVARCHAR (MAX)  NULL,
    [StockId]           NVARCHAR (MAX)  NULL,
    [KapanType]         NVARCHAR (MAX)  NULL
);

