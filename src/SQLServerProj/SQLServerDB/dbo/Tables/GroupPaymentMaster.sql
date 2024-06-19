CREATE TABLE [dbo].[GroupPaymentMaster] (
    [Id]              NVARCHAR (450) NOT NULL,
    [Sr]              INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]       NVARCHAR (MAX) NULL,
    [BranchId]        NVARCHAR (MAX) NULL,
    [FinancialYearId] NVARCHAR (MAX) NULL,
    [CrDrType]        INT            NOT NULL,
    [ToPartyId]       NVARCHAR (MAX) NULL,
    [BillNo]          INT            NOT NULL,
    [Remarks]         NVARCHAR (MAX) NULL,
    [IsDelete]        BIT            NOT NULL,
    [CreatedDate]     DATETIME2 (7)  NOT NULL,
    [UpdatedDate]     DATETIME2 (7)  NULL,
    [CreatedBy]       NVARCHAR (MAX) NULL,
    [UpdatedBy]       NVARCHAR (MAX) NULL,
    [Message]         NVARCHAR (MAX) NULL,
    [ApprovalType]    INT            NOT NULL,
    [EntryDate]       NVARCHAR (MAX) NULL,
    [EntryTime]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_GroupPaymentMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

