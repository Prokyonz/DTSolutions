﻿CREATE TABLE [dbo].[SPAccountToAssoftReceiveReportModel] (
    [Id]              NVARCHAR (MAX)  NULL,
    [Dept]            NVARCHAR (MAX)  NULL,
    [Sr]              INT             NOT NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [BranchId]        NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [JangadNo]        INT             NOT NULL,
    [EntryDate]       DATETIME2 (7)   NULL,
    [HandOverById]    NVARCHAR (MAX)  NULL,
    [HandOverByName]  NVARCHAR (MAX)  NULL,
    [HandOverToId]    NVARCHAR (MAX)  NULL,
    [HandOverToName]  NVARCHAR (MAX)  NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [KapanName]       NVARCHAR (MAX)  NULL,
    [ShapeId]         NVARCHAR (MAX)  NULL,
    [ShapeName]       NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [SizeName]        NVARCHAR (MAX)  NULL,
    [NumberId]        NVARCHAR (MAX)  NULL,
    [NumberName]      NVARCHAR (MAX)  NULL,
    [PurityId]        NVARCHAR (MAX)  NULL,
    [PurityName]      NVARCHAR (MAX)  NULL,
    [Remarks]         NVARCHAR (MAX)  NULL,
    [SlipNo]          NVARCHAR (MAX)  NULL,
    [Weight]          DECIMAL (18, 4) NOT NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [CreatedDate]     DATETIME2 (7)   NULL,
    [UpdatedBy]       NVARCHAR (MAX)  NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL
);
