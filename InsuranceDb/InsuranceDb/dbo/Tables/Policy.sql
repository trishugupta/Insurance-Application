CREATE TABLE [dbo].[Policy] (
    [PolicyId]                   BIGINT          IDENTITY (1, 1) NOT NULL,
    [PolicyCode]                 VARCHAR (500)   NOT NULL,
    [PurchaseDate]               DATETIME        NULL,
    [Fuel]                       VARCHAR (500)   NULL,
    [VehicleSegment]             VARCHAR (500)   NOT NULL,
    [Premium]                    DECIMAL (10, 2) NOT NULL,
    [bodily_injury_liability]    DECIMAL (10, 2) NULL,
    [personal_injury_protection] DECIMAL (10, 2) NULL,
    [property_damage_liability]  DECIMAL (10, 2) NULL,
    [collision]                  DECIMAL (10, 2) NULL,
    [comprehensive]              DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([PolicyId] ASC)
);

