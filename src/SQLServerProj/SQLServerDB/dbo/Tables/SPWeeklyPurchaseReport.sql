CREATE TABLE [dbo].[SPWeeklyPurchaseReport] (
    [WeekNo]          NVARCHAR (MAX) NULL,
    [Period]          NVARCHAR (MAX) NULL,
    [Amount]          FLOAT (53)     NOT NULL,
    [Week_End_Date]   NVARCHAR (MAX) NULL,
    [Week_Start_Date] NVARCHAR (MAX) NULL
);

