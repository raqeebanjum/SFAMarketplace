CREATE TABLE [dbo].[TransactionHistory] (
    [TransactionID]   INT      IDENTITY (1, 1) NOT NULL,
    [CartID]          INT      NULL,
    [BuyerID]         INT      NULL,
    [SellerID]        INT      NULL,
    [TransactionDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    FOREIGN KEY ([BuyerID]) REFERENCES [dbo].[Users] ([UserID]),
    FOREIGN KEY ([SellerID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [FK__Transacti__CartI__3D5E1FD2] FOREIGN KEY ([CartID]) REFERENCES [dbo].[Cart] ([CartID])
);

