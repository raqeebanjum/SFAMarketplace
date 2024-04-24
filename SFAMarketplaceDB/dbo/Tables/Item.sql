CREATE TABLE [dbo].[Item] (
    [ItemID]          INT             IDENTITY (1, 1) NOT NULL,
    [UserID]          INT             NULL,
    [ItemName]        VARCHAR (50)    NULL,
    [ItemDescription] VARCHAR (1500)  NULL,
    [ItemPhotoURL1]   VARCHAR (500)   NULL,
    [ItemPhotoURL2]   VARCHAR (500)   NULL,
    [ItemPhotoURL3]   VARCHAR (500)   NULL,
    [ItemPrice]       DECIMAL (10, 2) NULL,
    [CategoryID]      INT             NULL, 
    [ItemTradeStatus] BIT             NULL,
    [DatePosted]      DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CHECK ([ItemPrice] >= (0)),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID])
);
