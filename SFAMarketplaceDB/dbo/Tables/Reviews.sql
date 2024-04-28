CREATE TABLE [dbo].[Reviews] (
    [ReviewID]        INT           IDENTITY (1, 1) NOT NULL,
    [SellerID]        INT           NULL,
    [BuyerID]         INT           NULL,
    [Rating]          INT           NULL,
    [Comment]         VARCHAR (100) NULL,
    [TransactionDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ReviewID] ASC),
    FOREIGN KEY ([BuyerID]) REFERENCES [dbo].[Users] ([UserID]),
    FOREIGN KEY ([SellerID]) REFERENCES [dbo].[Users] ([UserID])
);

