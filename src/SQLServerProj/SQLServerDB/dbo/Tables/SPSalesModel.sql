﻿CREATE TABLE [dbo].[SPSalesModel] (
    [Id]              NVARCHAR (MAX)  NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [SaleBillNo]      BIGINT          NOT NULL,
    [SlipNo]          BIGINT          NOT NULL,
    [Date]            DATETIME2 (7)   NULL,
    [Time]            NVARCHAR (MAX)  NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [PartyName]       NVARCHAR (MAX)  NULL,
    [MobileNo]        NVARCHAR (MAX)  NULL,
    [SalerId]         NVARCHAR (MAX)  NULL,
    [SalerName]       NVARCHAR (MAX)  NULL,
    [SalerMobileNo]   NVARCHAR (MAX)  NULL,
    [BrokerageId]     NVARCHAR (MAX)  NULL,
    [BrokerName]      NVARCHAR (MAX)  NULL,
    [BrokerMobileNo]  NVARCHAR (MAX)  NULL,
    [Total]           FLOAT (53)      NOT NULL,
    [GrossTotal]      FLOAT (53)      NOT NULL,
    [DueDays]         INT             NOT NULL,
    [DueDate]         DATETIME2 (7)   NULL,
    [PaymentDays]     INT             NOT NULL,
    [PaymentDueDate]  DATETIME2 (7)   NULL,
    [IsPF]            BIT             NOT NULL,
    [IsSlip]          BIT             NOT NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL,
    [UpdatedBy]       NVARCHAR (MAX)  NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [Weight]          DECIMAL (18, 4) NOT NULL,
    [SaleRate]        FLOAT (53)      NOT NULL,
    [Remarks]         NVARCHAR (MAX)  NULL,
    [Message]         NVARCHAR (MAX)  NULL,
    [ApprovalType]    NVARCHAR (MAX)  NULL,
    [CVDAmount]       FLOAT (53)      DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [LessWeight]      DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [NetWeight]       DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [RoundUpAmount]   FLOAT (53)      DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [BranchName]      NVARCHAR (MAX)  NULL,
    [KapanName]       NVARCHAR (MAX)  NULL,
    [SizeName]        NVARCHAR (MAX)  NULL
);
