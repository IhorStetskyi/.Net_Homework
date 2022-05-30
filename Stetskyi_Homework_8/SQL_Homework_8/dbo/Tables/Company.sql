CREATE TABLE [dbo].[Company] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (20) NOT NULL,
    [AddressId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Company_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);