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
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (1, NULL, N'test', N'test', NULL, CAST(99.00 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T19:47:17.747' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (20, 1, N'Item 1 Category 1', N'Detailed description for Item 1 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(102.10 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (21, 1, N'Item 2 Category 1', N'Detailed description for Item 2 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(235.27 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (22, 1, N'Item 3 Category 1', N'Detailed description for Item 3 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(197.71 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (23, 1, N'Item 4 Category 1', N'Detailed description for Item 4 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(535.19 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (24, 1, N'Item 5 Category 1', N'Detailed description for Item 5 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(320.54 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (25, 1, N'Item 6 Category 1', N'Detailed description for Item 6 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(845.10 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (26, 1, N'Item 7 Category 1', N'Detailed description for Item 7 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(786.46 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (27, 1, N'Item 8 Category 1', N'Detailed description for Item 8 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(788.64 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (28, 1, N'Item 9 Category 1', N'Detailed description for Item 9 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(396.90 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (29, 1, N'Item 10 Category 1', N'Detailed description for Item 10 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(137.37 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (30, 1, N'Item 11 Category 1', N'Detailed description for Item 11 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(281.02 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (31, 1, N'Item 12 Category 1', N'Detailed description for Item 12 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(756.64 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (32, 1, N'Item 13 Category 1', N'Detailed description for Item 13 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(825.55 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (33, 1, N'Item 14 Category 1', N'Detailed description for Item 14 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(522.54 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (34, 1, N'Item 15 Category 1', N'Detailed description for Item 15 Category 1. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(918.69 AS Decimal(10, 2)), 1, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (35, 1, N'Item 1 Category 2', N'Detailed description for Item 1 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(508.04 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (36, 1, N'Item 2 Category 2', N'Detailed description for Item 2 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(395.89 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (37, 1, N'Item 3 Category 2', N'Detailed description for Item 3 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(138.12 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (38, 1, N'Item 4 Category 2', N'Detailed description for Item 4 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(512.15 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (39, 1, N'Item 5 Category 2', N'Detailed description for Item 5 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(331.31 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (40, 1, N'Item 6 Category 2', N'Detailed description for Item 6 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(400.18 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (41, 1, N'Item 7 Category 2', N'Detailed description for Item 7 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(996.29 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (42, 1, N'Item 8 Category 2', N'Detailed description for Item 8 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(688.90 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (43, 1, N'Item 9 Category 2', N'Detailed description for Item 9 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(349.54 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (44, 1, N'Item 10 Category 2', N'Detailed description for Item 10 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(261.98 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (45, 1, N'Item 11 Category 2', N'Detailed description for Item 11 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(121.46 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (46, 1, N'Item 12 Category 2', N'Detailed description for Item 12 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(721.66 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (47, 1, N'Item 13 Category 2', N'Detailed description for Item 13 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(910.27 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (48, 1, N'Item 14 Category 2', N'Detailed description for Item 14 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(151.21 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (49, 1, N'Item 15 Category 2', N'Detailed description for Item 15 Category 2. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(422.76 AS Decimal(10, 2)), 2, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (50, 1, N'Item 1 Category 3', N'Detailed description for Item 1 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(638.27 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (51, 1, N'Item 2 Category 3', N'Detailed description for Item 2 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(675.92 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (52, 1, N'Item 3 Category 3', N'Detailed description for Item 3 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(401.33 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (53, 1, N'Item 4 Category 3', N'Detailed description for Item 4 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(632.24 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (54, 1, N'Item 5 Category 3', N'Detailed description for Item 5 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(862.38 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (55, 1, N'Item 6 Category 3', N'Detailed description for Item 6 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(669.62 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (56, 1, N'Item 7 Category 3', N'Detailed description for Item 7 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(257.92 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (57, 1, N'Item 8 Category 3', N'Detailed description for Item 8 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(810.01 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (58, 1, N'Item 9 Category 3', N'Detailed description for Item 9 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(265.74 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (59, 1, N'Item 10 Category 3', N'Detailed description for Item 10 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(326.91 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (60, 1, N'Item 11 Category 3', N'Detailed description for Item 11 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(844.12 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (61, 1, N'Item 12 Category 3', N'Detailed description for Item 12 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(317.37 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (62, 1, N'Item 13 Category 3', N'Detailed description for Item 13 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(597.64 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (63, 1, N'Item 14 Category 3', N'Detailed description for Item 14 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(171.88 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (64, 1, N'Item 15 Category 3', N'Detailed description for Item 15 Category 3. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(987.01 AS Decimal(10, 2)), 3, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (65, 1, N'Item 1 Category 4', N'Detailed description for Item 1 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(211.61 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (66, 1, N'Item 2 Category 4', N'Detailed description for Item 2 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(798.08 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (67, 1, N'Item 3 Category 4', N'Detailed description for Item 3 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(349.13 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (68, 1, N'Item 4 Category 4', N'Detailed description for Item 4 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(711.04 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (69, 1, N'Item 5 Category 4', N'Detailed description for Item 5 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(854.88 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (70, 1, N'Item 6 Category 4', N'Detailed description for Item 6 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(367.35 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (71, 1, N'Item 7 Category 4', N'Detailed description for Item 7 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(917.87 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (72, 1, N'Item 8 Category 4', N'Detailed description for Item 8 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(600.18 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (73, 1, N'Item 9 Category 4', N'Detailed description for Item 9 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(151.86 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (74, 1, N'Item 10 Category 4', N'Detailed description for Item 10 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(271.52 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (75, 1, N'Item 11 Category 4', N'Detailed description for Item 11 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(121.02 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (76, 1, N'Item 12 Category 4', N'Detailed description for Item 12 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(458.38 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (77, 1, N'Item 13 Category 4', N'Detailed description for Item 13 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(547.18 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (78, 1, N'Item 14 Category 4', N'Detailed description for Item 14 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(273.00 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (79, 1, N'Item 15 Category 4', N'Detailed description for Item 15 Category 4. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(972.10 AS Decimal(10, 2)), 4, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (80, 1, N'Item 1 Category 5', N'Detailed description for Item 1 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(235.22 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (81, 1, N'Item 2 Category 5', N'Detailed description for Item 2 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(858.03 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (82, 1, N'Item 3 Category 5', N'Detailed description for Item 3 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(129.67 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (83, 1, N'Item 4 Category 5', N'Detailed description for Item 4 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(239.62 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (84, 1, N'Item 5 Category 5', N'Detailed description for Item 5 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(632.53 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (85, 1, N'Item 6 Category 5', N'Detailed description for Item 6 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(282.05 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (86, 1, N'Item 7 Category 5', N'Detailed description for Item 7 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(607.53 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (87, 1, N'Item 8 Category 5', N'Detailed description for Item 8 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(110.06 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (88, 1, N'Item 9 Category 5', N'Detailed description for Item 9 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(53.16 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (89, 1, N'Item 10 Category 5', N'Detailed description for Item 10 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(76.92 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (90, 1, N'Item 11 Category 5', N'Detailed description for Item 11 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(207.56 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (91, 1, N'Item 12 Category 5', N'Detailed description for Item 12 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(473.22 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (92, 1, N'Item 13 Category 5', N'Detailed description for Item 13 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(742.70 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (93, 1, N'Item 14 Category 5', N'Detailed description for Item 14 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(892.18 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (94, 1, N'Item 15 Category 5', N'Detailed description for Item 15 Category 5. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(129.19 AS Decimal(10, 2)), 5, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (95, 1, N'Item 1 Category 6', N'Detailed description for Item 1 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(636.28 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (96, 1, N'Item 2 Category 6', N'Detailed description for Item 2 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(804.83 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (97, 1, N'Item 3 Category 6', N'Detailed description for Item 3 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(68.09 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (98, 1, N'Item 4 Category 6', N'Detailed description for Item 4 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(543.21 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (99, 1, N'Item 5 Category 6', N'Detailed description for Item 5 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(849.93 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (100, 1, N'Item 6 Category 6', N'Detailed description for Item 6 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(664.10 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (101, 1, N'Item 7 Category 6', N'Detailed description for Item 7 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(445.15 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (102, 1, N'Item 8 Category 6', N'Detailed description for Item 8 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(737.45 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (103, 1, N'Item 9 Category 6', N'Detailed description for Item 9 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(828.25 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (104, 1, N'Item 10 Category 6', N'Detailed description for Item 10 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(429.60 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (105, 1, N'Item 11 Category 6', N'Detailed description for Item 11 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(449.52 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (106, 1, N'Item 12 Category 6', N'Detailed description for Item 12 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(101.32 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (107, 1, N'Item 13 Category 6', N'Detailed description for Item 13 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(607.62 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (108, 1, N'Item 14 Category 6', N'Detailed description for Item 14 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(961.91 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (109, 1, N'Item 15 Category 6', N'Detailed description for Item 15 Category 6. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(509.17 AS Decimal(10, 2)), 6, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (110, 1, N'Item 1 Category 7', N'Detailed description for Item 1 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(446.60 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (111, 1, N'Item 2 Category 7', N'Detailed description for Item 2 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(496.30 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (112, 1, N'Item 3 Category 7', N'Detailed description for Item 3 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(734.81 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (113, 1, N'Item 4 Category 7', N'Detailed description for Item 4 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(788.54 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (114, 1, N'Item 5 Category 7', N'Detailed description for Item 5 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(708.04 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (115, 1, N'Item 6 Category 7', N'Detailed description for Item 6 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(316.26 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (116, 1, N'Item 7 Category 7', N'Detailed description for Item 7 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(500.99 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (117, 1, N'Item 8 Category 7', N'Detailed description for Item 8 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(355.15 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (118, 1, N'Item 9 Category 7', N'Detailed description for Item 9 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(682.92 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (119, 1, N'Item 10 Category 7', N'Detailed description for Item 10 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(489.91 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (120, 1, N'Item 11 Category 7', N'Detailed description for Item 11 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(551.47 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (121, 1, N'Item 12 Category 7', N'Detailed description for Item 12 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(435.95 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (122, 1, N'Item 13 Category 7', N'Detailed description for Item 13 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(568.85 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (123, 1, N'Item 14 Category 7', N'Detailed description for Item 14 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(475.36 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (124, 1, N'Item 15 Category 7', N'Detailed description for Item 15 Category 7. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(921.68 AS Decimal(10, 2)), 7, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (125, 1, N'Item 1 Category 8', N'Detailed description for Item 1 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(75.21 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (126, 1, N'Item 2 Category 8', N'Detailed description for Item 2 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(560.46 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (127, 1, N'Item 3 Category 8', N'Detailed description for Item 3 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(684.60 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (128, 1, N'Item 4 Category 8', N'Detailed description for Item 4 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(638.63 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (129, 1, N'Item 5 Category 8', N'Detailed description for Item 5 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(884.53 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (130, 1, N'Item 6 Category 8', N'Detailed description for Item 6 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(834.03 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (131, 1, N'Item 7 Category 8', N'Detailed description for Item 7 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(537.98 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (132, 1, N'Item 8 Category 8', N'Detailed description for Item 8 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(836.67 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (133, 1, N'Item 9 Category 8', N'Detailed description for Item 9 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(626.57 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (134, 1, N'Item 10 Category 8', N'Detailed description for Item 10 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(724.31 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (135, 1, N'Item 11 Category 8', N'Detailed description for Item 11 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(936.83 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (136, 1, N'Item 12 Category 8', N'Detailed description for Item 12 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(238.88 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (137, 1, N'Item 13 Category 8', N'Detailed description for Item 13 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(178.12 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (138, 1, N'Item 14 Category 8', N'Detailed description for Item 14 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(970.59 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (139, 1, N'Item 15 Category 8', N'Detailed description for Item 15 Category 8. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(707.79 AS Decimal(10, 2)), 8, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (140, 1, N'Item 1 Category 9', N'Detailed description for Item 1 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(545.13 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (141, 1, N'Item 2 Category 9', N'Detailed description for Item 2 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(753.33 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (142, 1, N'Item 3 Category 9', N'Detailed description for Item 3 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(723.30 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (143, 1, N'Item 4 Category 9', N'Detailed description for Item 4 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(760.60 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (144, 1, N'Item 5 Category 9', N'Detailed description for Item 5 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(736.75 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (145, 1, N'Item 6 Category 9', N'Detailed description for Item 6 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(216.31 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (146, 1, N'Item 7 Category 9', N'Detailed description for Item 7 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(727.91 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (147, 1, N'Item 8 Category 9', N'Detailed description for Item 8 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(58.83 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (148, 1, N'Item 9 Category 9', N'Detailed description for Item 9 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(313.10 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (149, 1, N'Item 10 Category 9', N'Detailed description for Item 10 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(193.13 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (150, 1, N'Item 11 Category 9', N'Detailed description for Item 11 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(816.71 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (151, 1, N'Item 12 Category 9', N'Detailed description for Item 12 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(63.59 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (152, 1, N'Item 13 Category 9', N'Detailed description for Item 13 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(493.86 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (153, 1, N'Item 14 Category 9', N'Detailed description for Item 14 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(115.68 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (154, 1, N'Item 15 Category 9', N'Detailed description for Item 15 Category 9. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(403.31 AS Decimal(10, 2)), 9, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (155, 1, N'Item 1 Category 10', N'Detailed description for Item 1 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(130.57 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (156, 1, N'Item 2 Category 10', N'Detailed description for Item 2 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(385.09 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (157, 1, N'Item 3 Category 10', N'Detailed description for Item 3 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(215.63 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (158, 1, N'Item 4 Category 10', N'Detailed description for Item 4 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(940.24 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (159, 1, N'Item 5 Category 10', N'Detailed description for Item 5 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(120.01 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (160, 1, N'Item 6 Category 10', N'Detailed description for Item 6 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(297.10 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (161, 1, N'Item 7 Category 10', N'Detailed description for Item 7 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(828.62 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (162, 1, N'Item 8 Category 10', N'Detailed description for Item 8 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(349.32 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (163, 1, N'Item 9 Category 10', N'Detailed description for Item 9 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(714.33 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (164, 1, N'Item 10 Category 10', N'Detailed description for Item 10 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(706.53 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (165, 1, N'Item 11 Category 10', N'Detailed description for Item 11 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(533.24 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (166, 1, N'Item 12 Category 10', N'Detailed description for Item 12 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(568.45 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (167, 1, N'Item 13 Category 10', N'Detailed description for Item 13 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(386.88 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (168, 1, N'Item 14 Category 10', N'Detailed description for Item 14 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(825.06 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (169, 1, N'Item 15 Category 10', N'Detailed description for Item 15 Category 10. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(51.80 AS Decimal(10, 2)), 10, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (170, 1, N'Item 1 Category 11', N'Detailed description for Item 1 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(833.97 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (171, 1, N'Item 2 Category 11', N'Detailed description for Item 2 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(391.19 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (172, 1, N'Item 3 Category 11', N'Detailed description for Item 3 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(966.97 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (173, 1, N'Item 4 Category 11', N'Detailed description for Item 4 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(576.05 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (174, 1, N'Item 5 Category 11', N'Detailed description for Item 5 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(662.36 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (175, 1, N'Item 6 Category 11', N'Detailed description for Item 6 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(791.70 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (176, 1, N'Item 7 Category 11', N'Detailed description for Item 7 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(430.00 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (177, 1, N'Item 8 Category 11', N'Detailed description for Item 8 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(385.70 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (178, 1, N'Item 9 Category 11', N'Detailed description for Item 9 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(304.72 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (179, 1, N'Item 10 Category 11', N'Detailed description for Item 10 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(464.78 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (180, 1, N'Item 11 Category 11', N'Detailed description for Item 11 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(921.35 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (181, 1, N'Item 12 Category 11', N'Detailed description for Item 12 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(127.55 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (182, 1, N'Item 13 Category 11', N'Detailed description for Item 13 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(189.86 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (183, 1, N'Item 14 Category 11', N'Detailed description for Item 14 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(498.59 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (184, 1, N'Item 15 Category 11', N'Detailed description for Item 15 Category 11. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(145.36 AS Decimal(10, 2)), 11, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (185, 1, N'Item 1 Category 12', N'Detailed description for Item 1 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(703.51 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (186, 1, N'Item 2 Category 12', N'Detailed description for Item 2 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(287.14 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (187, 1, N'Item 3 Category 12', N'Detailed description for Item 3 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(686.19 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (188, 1, N'Item 4 Category 12', N'Detailed description for Item 4 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(481.98 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (189, 1, N'Item 5 Category 12', N'Detailed description for Item 5 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(719.58 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (190, 1, N'Item 6 Category 12', N'Detailed description for Item 6 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(124.32 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (191, 1, N'Item 7 Category 12', N'Detailed description for Item 7 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(861.10 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (192, 1, N'Item 8 Category 12', N'Detailed description for Item 8 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(978.92 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (193, 1, N'Item 9 Category 12', N'Detailed description for Item 9 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(217.02 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (194, 1, N'Item 10 Category 12', N'Detailed description for Item 10 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(279.17 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (195, 1, N'Item 11 Category 12', N'Detailed description for Item 11 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(200.70 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (196, 1, N'Item 12 Category 12', N'Detailed description for Item 12 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(422.36 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (197, 1, N'Item 13 Category 12', N'Detailed description for Item 13 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(86.92 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (198, 1, N'Item 14 Category 12', N'Detailed description for Item 14 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(541.33 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (199, 1, N'Item 15 Category 12', N'Detailed description for Item 15 Category 12. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(407.93 AS Decimal(10, 2)), 12, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (200, 1, N'Item 1 Category 13', N'Detailed description for Item 1 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(447.84 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (201, 1, N'Item 2 Category 13', N'Detailed description for Item 2 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(927.66 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (202, 1, N'Item 3 Category 13', N'Detailed description for Item 3 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(732.77 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (203, 1, N'Item 4 Category 13', N'Detailed description for Item 4 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(441.34 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (204, 1, N'Item 5 Category 13', N'Detailed description for Item 5 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(992.66 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (205, 1, N'Item 6 Category 13', N'Detailed description for Item 6 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(732.79 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (206, 1, N'Item 7 Category 13', N'Detailed description for Item 7 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(860.49 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (207, 1, N'Item 8 Category 13', N'Detailed description for Item 8 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(680.36 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (208, 1, N'Item 9 Category 13', N'Detailed description for Item 9 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(887.13 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (209, 1, N'Item 10 Category 13', N'Detailed description for Item 10 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(206.34 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (210, 1, N'Item 11 Category 13', N'Detailed description for Item 11 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(849.63 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (211, 1, N'Item 12 Category 13', N'Detailed description for Item 12 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(634.71 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (212, 1, N'Item 13 Category 13', N'Detailed description for Item 13 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(642.46 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (213, 1, N'Item 14 Category 13', N'Detailed description for Item 14 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(439.90 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (214, 1, N'Item 15 Category 13', N'Detailed description for Item 15 Category 13. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(369.68 AS Decimal(10, 2)), 13, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (215, 1, N'Item 1 Category 14', N'Detailed description for Item 1 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(870.47 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (216, 1, N'Item 2 Category 14', N'Detailed description for Item 2 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(556.97 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (217, 1, N'Item 3 Category 14', N'Detailed description for Item 3 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(748.47 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (218, 1, N'Item 4 Category 14', N'Detailed description for Item 4 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(909.93 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (219, 1, N'Item 5 Category 14', N'Detailed description for Item 5 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(946.61 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (220, 1, N'Item 6 Category 14', N'Detailed description for Item 6 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(792.26 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (221, 1, N'Item 7 Category 14', N'Detailed description for Item 7 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(75.05 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (222, 1, N'Item 8 Category 14', N'Detailed description for Item 8 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(967.25 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (223, 1, N'Item 9 Category 14', N'Detailed description for Item 9 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(250.42 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (224, 1, N'Item 10 Category 14', N'Detailed description for Item 10 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(541.62 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (225, 1, N'Item 11 Category 14', N'Detailed description for Item 11 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(274.04 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (226, 1, N'Item 12 Category 14', N'Detailed description for Item 12 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(294.12 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (227, 1, N'Item 13 Category 14', N'Detailed description for Item 13 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(956.81 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (228, 1, N'Item 14 Category 14', N'Detailed description for Item 14 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(814.72 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (229, 1, N'Item 15 Category 14', N'Detailed description for Item 15 Category 14. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(842.72 AS Decimal(10, 2)), 14, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (230, 1, N'Item 1 Category 15', N'Detailed description for Item 1 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(715.45 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (231, 1, N'Item 2 Category 15', N'Detailed description for Item 2 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(694.09 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (232, 1, N'Item 3 Category 15', N'Detailed description for Item 3 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(842.79 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (233, 1, N'Item 4 Category 15', N'Detailed description for Item 4 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(909.07 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (234, 1, N'Item 5 Category 15', N'Detailed description for Item 5 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(795.92 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (235, 1, N'Item 6 Category 15', N'Detailed description for Item 6 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(145.50 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (236, 1, N'Item 7 Category 15', N'Detailed description for Item 7 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(745.86 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (237, 1, N'Item 8 Category 15', N'Detailed description for Item 8 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(557.32 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (238, 1, N'Item 9 Category 15', N'Detailed description for Item 9 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(629.68 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (239, 1, N'Item 10 Category 15', N'Detailed description for Item 10 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(388.33 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (240, 1, N'Item 11 Category 15', N'Detailed description for Item 11 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(598.55 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (241, 1, N'Item 12 Category 15', N'Detailed description for Item 12 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(801.05 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (242, 1, N'Item 13 Category 15', N'Detailed description for Item 13 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(224.56 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (243, 1, N'Item 14 Category 15', N'Detailed description for Item 14 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(902.49 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
INSERT [dbo].[Item] ([ItemID], [UserID], [ItemName], [ItemDescription], [ItemPhotoURL1], [ItemPrice], [CategoryID], [ItemTradeStatus], [DatePosted]) VALUES (244, 1, N'Item 15 Category 15', N'Detailed description for Item 15 Category 15. This is one of the top items in this category providing exceptional value and performance.', NULL, CAST(795.54 AS Decimal(10, 2)), 15, 1, CAST(N'2024-04-13T20:08:04.590' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
