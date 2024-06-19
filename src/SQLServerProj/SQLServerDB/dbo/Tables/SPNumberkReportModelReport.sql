CREATE TABLE [dbo].[SPNumberkReportModelReport] (
    [Id]               INT             NOT NULL,
    [OperationType]    NVARCHAR (MAX)  NULL,
    [BranchName]       NVARCHAR (MAX)  NULL,
    [Number]           NVARCHAR (MAX)  NULL,
    [Size]             NVARCHAR (MAX)  NULL,
    [Kapan]            NVARCHAR (MAX)  NULL,
    [Category]         NVARCHAR (MAX)  NULL,
    [InwardNetWeight]  DECIMAL (18, 4) NOT NULL,
    [InwardRate]       DECIMAL (18, 4) NOT NULL,
    [InwardAmount]     DECIMAL (18, 4) NOT NULL,
    [OutwardNetWeight] DECIMAL (18, 4) NOT NULL,
    [OutwardRate]      DECIMAL (18, 4) NOT NULL,
    [OutwardAmount]    DECIMAL (18, 4) NOT NULL,
    [ClosingAmount]    DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [ClosingNetWeight] DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [ClosingRate]      DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [Date]             DATETIME2 (7)   NULL
);

