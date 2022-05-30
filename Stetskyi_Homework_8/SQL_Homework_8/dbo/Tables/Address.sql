CREATE TABLE [dbo].[Address] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Street]  NVARCHAR (50) NULL,
    [City]    NVARCHAR (20) NULL,
    [State]   NVARCHAR (20) NULL,
    [ZipCode] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);