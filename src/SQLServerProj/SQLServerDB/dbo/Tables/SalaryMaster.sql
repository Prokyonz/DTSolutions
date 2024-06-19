CREATE TABLE [dbo].[SalaryMaster] (
    [Id]                  NVARCHAR (450) NOT NULL,
    [Sr]                  INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]           NVARCHAR (MAX) NULL,
    [BranchId]            NVARCHAR (MAX) NULL,
    [FinancialYearId]     NVARCHAR (MAX) NULL,
    [SalaryMonthDateTime] DATETIME2 (7)  NOT NULL,
    [MonthDays]           INT            NOT NULL,
    [Holidays]            REAL           NOT NULL,
    [Remarks]             NVARCHAR (MAX) NULL,
    [CreatedDate]         DATETIME2 (7)  NOT NULL,
    [UpdatedDate]         DATETIME2 (7)  NULL,
    [CreatedBy]           NVARCHAR (MAX) NULL,
    [UpdatedBy]           NVARCHAR (MAX) NULL,
    [FromPartyId]         NVARCHAR (MAX) NULL,
    [SalaryMonth]         INT            DEFAULT ((0)) NOT NULL,
    [SrNo]                INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SalaryMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

