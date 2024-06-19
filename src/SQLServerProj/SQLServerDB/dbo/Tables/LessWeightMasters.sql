CREATE TABLE [dbo].[LessWeightMasters] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Sr]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [IsDelete]    BIT            NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LessWeightMasters] PRIMARY KEY CLUSTERED ([Id] ASC)
);

