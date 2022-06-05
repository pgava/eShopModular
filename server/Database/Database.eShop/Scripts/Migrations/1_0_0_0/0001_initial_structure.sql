
PRINT N'Creating [order]...';


GO
CREATE SCHEMA [order]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [country]...';


GO
CREATE SCHEMA [country]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [product]...';


GO
CREATE SCHEMA [product]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating [order].[Orders]...';


GO
CREATE TABLE [order].[Orders] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [ShippingCost]   DECIMAL (18, 2)  NOT NULL,
    [TotalCost]      DECIMAL (18, 2)  NOT NULL,
    [Currency]       VARCHAR (3)      NOT NULL,
    [ExchangeRate]   DECIMAL (18, 2)  NOT NULL,
    [CreateDate]     DATETIME         NOT NULL,
    CONSTRAINT [PK_order_Orders_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
PRINT N'Creating [order].[Items]...';


GO
CREATE TABLE [order].[Items] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [OrderId]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId]  UNIQUEIDENTIFIER NOT NULL,
    [Quantity]   INT              NOT NULL,
    [Price]      DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_order_Items_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_order_Items_Orders] FOREIGN KEY ([OrderId]) REFERENCES [order].[Orders] ([Id]),
);


GO
PRINT N'Creating [country].[Countries]...';


GO
CREATE TABLE [country].[Countries] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CountryName]     VARCHAR(255)     NOT NULL,
    [CurrencyCode]    VARCHAR(3)       NOT NULL,
    [CurrencySymbol]  NVARCHAR(1)      NOT NULL,
    [ExchangeRate]    DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_country_Countries_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [product].[Products]...';


GO
CREATE TABLE [product].[Products] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [Name]          VARCHAR(255)     NOT NULL,
    [Description]   VARCHAR(MAX)     NULL,
    [Price]         DECIMAL (18, 2)  NOT NULL,
    [ImageUrl]      VARCHAR(255)     NULL,
    CONSTRAINT [PK_product_Products_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Update complete.';


GO
