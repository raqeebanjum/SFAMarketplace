CREATE TABLE [dbo].[TransactionLocation] (
    [LocationID]   INT          IDENTITY (1, 1) NOT NULL,
    [LocationName] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([LocationID] ASC)
);

