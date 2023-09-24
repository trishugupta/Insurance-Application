CREATE TABLE [dbo].[Customer] (
    [CustomerId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserName]      VARCHAR (500) NOT NULL,
    [FirstName]     VARCHAR (200) NULL,
    [LastName]      VARCHAR (200) NULL,
    [Gender]        VARCHAR (10)  NOT NULL,
    [Incomegroup]   VARCHAR (500) NOT NULL,
    [Region]        VARCHAR (500) NOT NULL,
    [Maritalstatus] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

