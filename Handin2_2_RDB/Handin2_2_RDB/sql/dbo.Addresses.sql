CREATE TABLE [dbo].[Addresses] (
    [City] NVARCHAR (128) NOT NULL,
    [Hanscity] NCHAR(10) NULL, 
    CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY CLUSTERED ([City] ASC)
);

