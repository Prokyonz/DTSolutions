CREATE TABLE [dbo].[SPPaymentPSSlipDetails] (
    [PurchaseId]      NVARCHAR (MAX) NULL,
    [Date]            NVARCHAR (MAX) NULL,
    [PartyId]         NVARCHAR (MAX) NULL,
    [Party]           NVARCHAR (MAX) NULL,
    [SlipNo]          BIGINT         NOT NULL,
    [CompanyId]       NVARCHAR (MAX) NULL,
    [BranchId]        NVARCHAR (MAX) NULL,
    [FinancialYearId] NVARCHAR (MAX) NULL,
    [Year]            NVARCHAR (MAX) NULL,
    [GrossTotal]      FLOAT (53)     NOT NULL,
    [RemainAmount]    FLOAT (53)     NOT NULL
);

