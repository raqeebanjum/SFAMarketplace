CREATE TABLE [dbo].[ServicesInCart] (
    [CartServiceID] INT IDENTITY (1, 1) NOT NULL,
    [CartID]        INT NULL,
    [ServiceID]     INT NULL,
    [LocationID]    INT NULL,
    PRIMARY KEY CLUSTERED ([CartServiceID] ASC),
    FOREIGN KEY ([LocationID]) REFERENCES [dbo].[TransactionLocation] ([LocationID]),
    FOREIGN KEY ([ServiceID]) REFERENCES [dbo].[Services] ([ServiceID]),
    CONSTRAINT [FK__ServicesI__CartI__4222D4EF] FOREIGN KEY ([CartID]) REFERENCES [dbo].[Cart] ([CartID])
);

