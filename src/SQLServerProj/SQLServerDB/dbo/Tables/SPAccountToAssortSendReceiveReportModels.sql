﻿CREATE TABLE [dbo].[SPAccountToAssortSendReceiveReportModels] (
    [Id]                  NVARCHAR (MAX)  NULL,
    [ChildId]             NVARCHAR (MAX)  NULL,
    [Sr]                  INT             NOT NULL,
    [Department]          NVARCHAR (MAX)  NULL,
    [CompanyId]           NVARCHAR (MAX)  NULL,
    [BranchId]            NVARCHAR (MAX)  NULL,
    [FinancialYearId]     NVARCHAR (MAX)  NULL,
    [EntryDate]           DATETIME2 (7)   NULL,
    [FromPartyId]         NVARCHAR (MAX)  NULL,
    [FromPartyName]       NVARCHAR (MAX)  NULL,
    [ToPartyId]           NVARCHAR (MAX)  NULL,
    [ToPartyName]         NVARCHAR (MAX)  NULL,
    [KapanId]             NVARCHAR (MAX)  NULL,
    [KapanName]           NVARCHAR (MAX)  NULL,
    [AccountToAssortType] INT             NOT NULL,
    [Remarks]             NVARCHAR (MAX)  NULL,
    [SlipNo]              NVARCHAR (MAX)  NULL,
    [SizeId]              NVARCHAR (MAX)  NULL,
    [SizeName]            NVARCHAR (MAX)  NULL,
    [Weight]              DECIMAL (18, 4) NOT NULL,
    [AssignWeight]        DECIMAL (18, 4) NOT NULL,
    [CreatedBy]           NVARCHAR (MAX)  NULL,
    [CreatedDate]         DATETIME2 (7)   NULL,
    [UpdatedBy]           NVARCHAR (MAX)  NULL,
    [UpdatedDate]         DATETIME2 (7)   NULL
);

