CREATE TABLE [dbo].[SPPFReportModels] (
    [Type]            NVARCHAR (MAX)  NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [PartyName]       NVARCHAR (MAX)  NULL,
    [BrokerId]        NVARCHAR (MAX)  NULL,
    [BrokerName]      NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [NumberId]        NVARCHAR (MAX)  NULL,
    [Number]          NVARCHAR (MAX)  NULL,
    [Weight]          DECIMAL (18, 4) NOT NULL,
    [NetWeight]       DECIMAL (18, 4) NOT NULL,
    [Rate]            FLOAT (53)      NOT NULL,
    [Amount]          FLOAT (53)      NOT NULL,
    [CreatedDate]     DATETIME2 (7)   NOT NULL
);

