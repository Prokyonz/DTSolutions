CREATE TABLE [dbo].[UserPermissionChild] (
    [Id]                 NVARCHAR (450) NOT NULL,
    [Sr]                 INT            IDENTITY (1, 1) NOT NULL,
    [PermissionMasterId] NVARCHAR (MAX) NULL,
    [UserId]             NVARCHAR (450) NULL,
    [KeyName]            NVARCHAR (MAX) NULL,
    [Status]             BIT            NOT NULL,
    CONSTRAINT [PK_UserPermissionChild] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPermissionChild_UserMaster_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserMaster] ([Id])
);

