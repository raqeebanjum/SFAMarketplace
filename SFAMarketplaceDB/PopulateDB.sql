/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Username], [Email], [PasswordHash], [ProfilePictureURL], [Role], [LastLoginTime]) VALUES (1, N'Johnny', N'Appleseed', NULL, N'jonnyappleseed@jacks.sfasu.edu', N'$2a$13$vg7GqkwV/AFnQ2ofrKQl9uQP/jemcXYeoARcTkmJO5NTzuBgqXrzu', NULL, 0, CAST(N'2024-03-28T15:34:32.887' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
