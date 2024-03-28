CREATE TABLE [dbo].[ItemsInCart] (
    [CartItemID] INT IDENTITY (1, 1) NOT NULL,
    [CartID]     INT NULL,
    [ItemID]     INT NULL,
    [LocationID] INT NULL,
    PRIMARY KEY CLUSTERED ([CartItemID] ASC),
    FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID]),
    FOREIGN KEY ([LocationID]) REFERENCES [dbo].[TransactionLocation] ([LocationID]),
    CONSTRAINT [FK__ItemsInCa__CartI__46E78A0C] FOREIGN KEY ([CartID]) REFERENCES [dbo].[Cart] ([CartID])
);

