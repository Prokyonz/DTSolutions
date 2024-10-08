﻿CREATE TABLE [dbo].[SPLoanReportModel] (
    [Id]              NVARCHAR (MAX)  NULL,
    [Sr]              INT             NOT NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [CompanyName]     NVARCHAR (MAX)  NULL,
    [LoanType]        NVARCHAR (MAX)  NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [PartyName]       NVARCHAR (MAX)  NULL,
    [Amount]          DECIMAL (18, 2) NOT NULL,
    [DuratonType]     INT             NOT NULL,
    [StartDate]       DATETIME2 (7)   NULL,
    [EndDate]         DATETIME2 (7)   NULL,
    [InterestRate]    DECIMAL (18, 2) NOT NULL,
    [TotalInterest]   DECIMAL (18, 2) NOT NULL,
    [NetAmount]       DECIMAL (18, 2) NOT NULL,
    [Remarks]         NVARCHAR (MAX)  NULL,
    [IsDelete]        BIT             NOT NULL,
    [CreatedDate]     DATETIME2 (7)   NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [UpdatedBy]       NVARCHAR (MAX)  NULL,
    [CashBankName]    NVARCHAR (MAX)  NULL,
    [CashBankPartyId] NVARCHAR (MAX)  NULL,
    [EntryDate]       DATETIME2 (7)   NULL,
    [EntryTime]       NVARCHAR (MAX)  NULL
);

