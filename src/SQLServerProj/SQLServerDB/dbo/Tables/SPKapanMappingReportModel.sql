CREATE TABLE [dbo].[SPKapanMappingReportModel] (
    [Id]                NVARCHAR (MAX)  NULL,
    [Sr]                INT             NOT NULL,
    [CompanyId]         NVARCHAR (MAX)  NULL,
    [BranchId]          NVARCHAR (MAX)  NULL,
    [FinancialYearId]   NVARCHAR (MAX)  NULL,
    [SlipNo]            NVARCHAR (MAX)  NULL,
    [KapanId]           NVARCHAR (MAX)  NULL,
    [Name]              NVARCHAR (MAX)  NULL,
    [Weight]            DECIMAL (18, 4) NOT NULL,
    [CreatedBy]         NVARCHAR (MAX)  NULL,
    [CreatedDate]       DATETIME2 (7)   NULL,
    [UpdatedBy]         NVARCHAR (MAX)  NULL,
    [UpdatedDate]       DATETIME2 (7)   NULL,
    [PurchaseDetailsId] NVARCHAR (MAX)  NULL
);

