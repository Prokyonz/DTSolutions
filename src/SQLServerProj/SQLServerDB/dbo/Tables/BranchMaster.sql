﻿CREATE TABLE [dbo].[BranchMaster] (
    [Id]             NVARCHAR (450)  NOT NULL,
    [Sr]             INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]      NVARCHAR (450)  NULL,
    [LessWeightId]   NVARCHAR (MAX)  NULL,
    [Name]           NVARCHAR (MAX)  NULL,
    [Address]        NVARCHAR (MAX)  NULL,
    [Address2]       NVARCHAR (MAX)  NULL,
    [MobileNo]       NVARCHAR (MAX)  NULL,
    [OfficeNo]       NVARCHAR (MAX)  NULL,
    [Details]        NVARCHAR (MAX)  NULL,
    [TermsCondition] NVARCHAR (MAX)  NULL,
    [GSTNo]          NVARCHAR (MAX)  NULL,
    [PanCardNo]      NVARCHAR (MAX)  NULL,
    [RegistrationNo] NVARCHAR (MAX)  NULL,
    [CVDWeight]      DECIMAL (18, 4) NOT NULL,
    [TipWeight]      DECIMAL (18, 4) NOT NULL,
    [IsDelete]       BIT             NOT NULL,
    [CreatedDate]    DATETIME2 (7)   NOT NULL,
    [UpdatedDate]    DATETIME2 (7)   NULL,
    [CreatedBy]      NVARCHAR (MAX)  NULL,
    [UpdatedBy]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_BranchMaster] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BranchMaster_CompanyMaster_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CompanyMaster] ([Id])
);

