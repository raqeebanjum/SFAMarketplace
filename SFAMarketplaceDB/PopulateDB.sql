SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Username], [Email], [PasswordHash], [ProfilePictureURL], [Role], [LastLoginTime]) VALUES (1, N'Johnny', N'Appleseed', N'Johnny', N'johnny@sfa.com', N'$2a$13$1wulEcBcSQ2HJKtiw8aJXu6BvHntMJPdwsmNsvH01qkgHJe00vKPG', NULL, 1, CAST(N'2024-04-13T20:07:19.073' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'Electronics')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Books')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Home & Garden')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (4, N'Fashion')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (5, N'Toys')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (6, N'Sports')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (7, N'Music')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (8, N'Health & Beauty')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (9, N'Pets')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (10, N'Vehicles')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (11, N'Art & Collectibles')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (12, N'Baby Products')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (13, N'Food & Drink')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (14, N'Office Supplies')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (15, N'Other')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 
GO
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
