﻿CREATE TABLE [dbo].[PurchaseMaster] (
    [Id]                            VARCHAR (100)   NOT NULL,
    [Sr]                            INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]                     VARCHAR (100)   NOT NULL,
    [BranchId]                      NVARCHAR (MAX)  NULL,
    [PartyId]                       NVARCHAR (MAX)  NULL,
    [ByuerId]                       NVARCHAR (MAX)  NULL,
    [CurrencyId]                    NVARCHAR (MAX)  NULL,
    [FinancialYearId]               VARCHAR (100)   NOT NULL,
    [BrokerageId]                   NVARCHAR (MAX)  NULL,
    [CurrencyRate]                  DECIMAL (18, 4) NOT NULL,
    [PurchaseBillNo]                BIGINT          NOT NULL,
    [ApprovalType]                  INT             NOT NULL,
    [Message]                       NVARCHAR (MAX)  NULL,
    [SlipNo]                        BIGINT          NOT NULL,
    [TransactionType]               INT             NOT NULL,
    [Date]                          NVARCHAR (MAX)  NULL,
    [Time]                          NVARCHAR (MAX)  NULL,
    [DayName]                       NVARCHAR (MAX)  NULL,
    [PartyLastBalanceWhilePurchase] FLOAT (53)      NOT NULL,
    [BrokerPercentage]              DECIMAL (18, 4) NOT NULL,
    [BrokerAmount]                  FLOAT (53)      NOT NULL,
    [RoundUpAmount]                 FLOAT (53)      NOT NULL,
    [Total]                         FLOAT (53)      NOT NULL,
    [GrossTotal]                    FLOAT (53)      NOT NULL,
    [DueDays]                       INT             NOT NULL,
    [DueDate]                       DATETIME2 (7)   NOT NULL,
    [PaymentDays]                   INT             NOT NULL,
    [PaymentDueDate]                DATETIME2 (7)   NOT NULL,
    [IsSlip]                        BIT             NOT NULL,
    [IsPF]                          BIT             NOT NULL,
    [CommissionPercentage]          DECIMAL (18, 4) NOT NULL,
    [CommissionAmount]              FLOAT (53)      NOT NULL,
    [Image1]                        VARBINARY (MAX) NULL,
    [Image2]                        VARBINARY (MAX) NULL,
    [Image3]                        VARBINARY (MAX) NULL,
    [AllowSlipPrint]                BIT             NOT NULL,
    [IsTransfer]                    BIT             NOT NULL,
    [TransferParentId]              NVARCHAR (MAX)  NULL,
    [IsDelete]                      BIT             NOT NULL,
    [Remarks]                       NVARCHAR (MAX)  NULL,
    [CreatedDate]                   DATETIME2 (7)   NOT NULL,
    [UpdatedDate]                   DATETIME2 (7)   NULL,
    [CreatedBy]                     NVARCHAR (MAX)  NULL,
    [UpdatedBy]                     NVARCHAR (MAX)  NULL,
    [IsSlipPrint]                   BIT             DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_PurchaseMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);
