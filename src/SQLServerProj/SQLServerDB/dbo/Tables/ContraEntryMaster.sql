CREATE TABLE [dbo].[ContraEntryMaster] (
    [Id]              NVARCHAR (450) NOT NULL,
    [Sr]              INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]       NVARCHAR (MAX) NULL,
    [BranchId]        NVARCHAR (MAX) NULL,
    [FinancialYearId] NVARCHAR (MAX) NULL,
    [ToPartyId]       NVARCHAR (MAX) NULL,
    [Remarks]         NVARCHAR (MAX) NULL,
    [IsDelete]        BIT            NOT NULL,
    [CreatedDate]     DATETIME2 (7)  NOT NULL,
    [UpdatedDate]     DATETIME2 (7)  NULL,
    [CreatedBy]       NVARCHAR (MAX) NULL,
    [UpdatedBy]       NVARCHAR (MAX) NULL,
    [EntryDate]       NVARCHAR (MAX) NULL,
    [SrNo]            INT            DEFAULT ((0)) NOT NULL,
    [EntryTime]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ContraEntryMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

