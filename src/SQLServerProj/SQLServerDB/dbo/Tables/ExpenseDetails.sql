﻿CREATE TABLE [dbo].[ExpenseDetails] (
    [Id]              NVARCHAR (450) NOT NULL,
    [Sr]              INT            IDENTITY (1, 1) NOT NULL,
    [SrNo]            INT            NOT NULL,
    [CompanyId]       NVARCHAR (MAX) NULL,
    [BranchId]        NVARCHAR (MAX) NULL,
    [FinancialYearId] NVARCHAR (MAX) NULL,
    [PartyId]         NVARCHAR (450) NULL,
    [fromPartyId]     NVARCHAR (MAX) NULL,
    [Amount]          FLOAT (53)     NOT NULL,
    [Remarks]         NVARCHAR (MAX) NULL,
    [IsDelete]        BIT            NOT NULL,
    [CreatedDate]     DATETIME2 (7)  NOT NULL,
    [UpdatedDate]     DATETIME2 (7)  NULL,
    [CreatedBy]       NVARCHAR (MAX) NULL,
    [UpdatedBy]       NVARCHAR (MAX) NULL,
    [Message]         NVARCHAR (MAX) NULL,
    [ApprovalType]    INT            NOT NULL,
    [ExpenseMasterId] NVARCHAR (450) NULL,
    [EntryDate]       NVARCHAR (MAX) NULL,
    [CrDrType]        INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ExpenseDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ExpenseDetails_ExpenseMaster_ExpenseMasterId] FOREIGN KEY ([ExpenseMasterId]) REFERENCES [dbo].[ExpenseMaster] ([Id]),
    CONSTRAINT [FK_ExpenseDetails_PartyMaster_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[PartyMaster] ([Id])
);
