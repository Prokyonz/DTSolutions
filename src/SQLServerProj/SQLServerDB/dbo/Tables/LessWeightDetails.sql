CREATE TABLE [dbo].[LessWeightDetails] (
    [Id]           NVARCHAR (450)  NOT NULL,
    [Sr]           INT             IDENTITY (1, 1) NOT NULL,
    [LessWeightId] NVARCHAR (450)  NULL,
    [MinWeight]    DECIMAL (18, 4) NOT NULL,
    [MaxWeight]    DECIMAL (18, 4) NOT NULL,
    [LessWeight]   DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_LessWeightDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LessWeightDetails_LessWeightMasters_LessWeightId] FOREIGN KEY ([LessWeightId]) REFERENCES [dbo].[LessWeightMasters] ([Id])
);

