CREATE TABLE [dbo].[LoanMaster] (
    [Id]              NVARCHAR (450)  NOT NULL,
    [Sr]              INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]       VARCHAR (50)    NOT NULL,
    [LoanType]        INT             NOT NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [Amount]          DECIMAL (18, 2) NOT NULL,
    [DuratonType]     INT             NOT NULL,
    [StartDate]       DATETIME2 (7)   NULL,
    [EndDate]         DATETIME2 (7)   NULL,
    [InterestRate]    DECIMAL (18, 2) NOT NULL,
    [TotalInterest]   DECIMAL (18, 2) NOT NULL,
    [NetAmount]       DECIMAL (18, 2) NOT NULL,
    [Remarks]         NVARCHAR (MAX)  NULL,
    [IsDelete]        BIT             NOT NULL,
    [CreatedDate]     DATETIME2 (7)   NOT NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [UpdatedBy]       NVARCHAR (MAX)  NULL,
    [CashBankPartyId] NVARCHAR (MAX)  NULL,
    [EntryTime]       NVARCHAR (MAX)  NULL,
    [EntryDate]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_LoanMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_LoanMaster_CompanyId_FinancialYearId_IsDelete]
    ON [dbo].[LoanMaster]([CompanyId] ASC, [FinancialYearId] ASC, [IsDelete] ASC);

