CREATE TABLE [dbo].[SPKapanMapping] (
    [Date]             DATETIME2 (7)   NOT NULL,
    [SlipNo]           BIGINT          NOT NULL,
    [SizeId]           NVARCHAR (MAX)  NULL,
    [Size]             NVARCHAR (MAX)  NULL,
    [NetWeight]        DECIMAL (18, 2) NOT NULL,
    [AvailableCts]     DECIMAL (18, 2) NOT NULL,
    [Cts]              DECIMAL (18, 2) NULL,
    [PurchaseID]       NVARCHAR (MAX)  NULL,
    [PurchaseDetailId] NVARCHAR (MAX)  NULL,
    [KapanId]          NVARCHAR (MAX)  NULL,
    [Remarks]          NVARCHAR (MAX)  NULL
);

