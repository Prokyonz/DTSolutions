CREATE TABLE [dbo].[ExpenseMaster] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Sr]          INT            IDENTITY (1, 1) NOT NULL,
    [BranchId]    NVARCHAR (MAX) NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [IsDelete]    BIT            NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ExpenseMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

