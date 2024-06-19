CREATE TABLE [dbo].[SPKapanLagadReportModel] (
    [Id]                   INT             NOT NULL,
    [Date]                 DATETIME2 (7)   NOT NULL,
    [SlipNo]               BIGINT          NOT NULL,
    [Party]                NVARCHAR (MAX)  NULL,
    [NetWeight]            DECIMAL (18, 2) NULL,
    [Rate]                 DECIMAL (18, 2) NULL,
    [Amount]               DECIMAL (18, 2) NULL,
    [Category]             NVARCHAR (MAX)  NULL,
    [CategoryId]           INT             NOT NULL,
    [Kapan]                NVARCHAR (MAX)  NULL,
    [ProfitLossPer]        DECIMAL (18, 2) NULL,
    [Records]              INT             DEFAULT ((0)) NOT NULL,
    [InwardAvg]            DECIMAL (18, 2) NULL,
    [OperationType]        NVARCHAR (MAX)  NULL,
    [OutwardAvg]           DECIMAL (18, 2) NULL,
    [PerCts]               DECIMAL (18, 2) NULL,
    [Size]                 NVARCHAR (MAX)  NULL,
    [TotalSizeGroupWeight] DECIMAL (18, 2) NULL
);

