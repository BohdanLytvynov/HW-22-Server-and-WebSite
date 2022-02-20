CREATE TABLE [dbo].[Notes] (
    [Id]          UNIQUEIDENTIFIER             NOT NULL,
    [Surename]    NVARCHAR (20)   NOT NULL,
    [Name]        NVARCHAR (20)   NOT NULL,
    [Lastname]    NVARCHAR (20)   NOT NULL,
    [Phone]       NVARCHAR (20)   NOT NULL,
    [Adress]      NVARCHAR (200)  NOT NULL,
    [Description] NVARCHAR (3000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);