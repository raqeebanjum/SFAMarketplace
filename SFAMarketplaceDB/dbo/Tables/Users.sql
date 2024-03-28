CREATE TABLE [dbo].[Users] (
    [UserID]            INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]         VARCHAR (50)  NULL,
    [LastName]          VARCHAR (50)  NULL,
    [Username]          VARCHAR (50)  NULL,
    [Email]             VARCHAR (100) NULL,
    [PasswordHash]      VARCHAR (100) NULL,
    [ProfilePictureURL] VARCHAR (200) NULL,
    [Role]              INT           NULL,
    [LastLoginTime]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);
