CREATE TABLE [dbo].[SizeMaster] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [IsDelete]    BIT            NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SizeMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

