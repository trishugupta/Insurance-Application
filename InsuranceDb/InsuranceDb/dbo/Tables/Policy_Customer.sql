CREATE TABLE [dbo].[Policy_Customer] (
    [PolicyCustomerId] BIGINT IDENTITY (1, 1) NOT NULL,
    [PolicyId]         BIGINT NULL,
    [CustomerId]       BIGINT NULL,
    PRIMARY KEY CLUSTERED ([PolicyCustomerId] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    FOREIGN KEY ([PolicyId]) REFERENCES [dbo].[Policy] ([PolicyId])
);

