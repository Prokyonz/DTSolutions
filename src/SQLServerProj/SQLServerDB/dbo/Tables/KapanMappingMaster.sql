CREATE TABLE [dbo].[KapanMappingMaster] (
    [Id]                NVARCHAR (450)  NOT NULL,
    [Sr]                INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]         NVARCHAR (MAX)  NULL,
    [BranchId]          NVARCHAR (MAX)  NULL,
    [FinancialYearId]   NVARCHAR (MAX)  NULL,
    [PurchaseMasterId]  NVARCHAR (MAX)  NULL,
    [PurchaseDetailsId] NVARCHAR (MAX)  NULL,
    [KapanId]           NVARCHAR (MAX)  NULL,
    [PurityId]          NVARCHAR (MAX)  NULL,
    [SlipNo]            NVARCHAR (MAX)  NULL,
    [Weight]            DECIMAL (18, 4) NOT NULL,
    [CreatedDate]       DATETIME2 (7)   NOT NULL,
    [CreatedBy]         NVARCHAR (MAX)  NULL,
    [UpdatedDate]       DATETIME2 (7)   NULL,
    [UpdatedBy]         NVARCHAR (MAX)  NULL,
    [TransferCaratRate] FLOAT (53)      DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [TransferEntryId]   NVARCHAR (MAX)  NULL,
    [TransferId]        NVARCHAR (MAX)  NULL,
    [TransferType]      NVARCHAR (MAX)  NULL,
    [Remarks]           NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_KapanMappingMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

