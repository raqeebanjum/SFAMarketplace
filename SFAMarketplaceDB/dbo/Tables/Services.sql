CREATE TABLE [dbo].[Services] (
    [ServiceID]          INT             IDENTITY (1, 1) NOT NULL,
    [UserID]             INT             NULL,
    [ServiceTitle]       VARCHAR (250)   NULL,
    [ServiceDescription] VARCHAR (500)   NULL,
    [ServiceRate]        DECIMAL (10, 2) NULL,
    [DatePosted]         DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([ServiceID] ASC),
    CHECK ([ServiceRate]>=(0)),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

