CREATE TABLE [dbo].[Contacts] (
    [Hans]         NVARCHAR (128) NOT NULL,
    [MiddleName]   NVARCHAR (MAX) NULL,
    [SurName]      NVARCHAR (MAX) NULL,
    [Email]        NVARCHAR (MAX) NULL,
    [Address_City] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED ([Hans] ASC),
    CONSTRAINT [FK_dbo.Contacts_dbo.Addresses_Address_City] FOREIGN KEY ([Address_City]) REFERENCES [dbo].[Addresses] ([City])
);


GO
CREATE NONCLUSTERED INDEX [IX_Address_City]
    ON [dbo].[Contacts]([Address_City] ASC);

