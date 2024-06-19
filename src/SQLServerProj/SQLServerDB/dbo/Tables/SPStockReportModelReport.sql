CREATE TABLE [dbo].[SPStockReportModelReport] (
    [KapanId]          NVARCHAR (MAX)  NULL,
    [OutwardRate]      DECIMAL (18, 4) NOT NULL,
    [OutwardAmount]    DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [OutwardNetWeight] DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [InwardAmount]     DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [InwardNetWeight]  DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [InwardRate]       DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [BranchName]       NVARCHAR (MAX)  NULL,
    [Name]             NVARCHAR (MAX)  NULL,
    [Party]            NVARCHAR (MAX)  NULL,
    [ClosingAmount]    DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [ClosingNetWeight] DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [ClosingRate]      DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [Date]             DATETIME2 (7)   NULL
);

