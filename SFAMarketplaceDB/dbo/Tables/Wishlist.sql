CREATE TABLE [dbo].[Wishlist] (
    [WishlistID] INT IDENTITY (1, 1) NOT NULL,
    [UserID]     INT NULL,
    [ItemID]     INT NULL,
    PRIMARY KEY CLUSTERED ([WishlistID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [UC_UserItem] UNIQUE NONCLUSTERED ([UserID] ASC, [ItemID] ASC)
);

