TRUNCATE TABLE [Customer]
GO
INSERT INTO [Customer] ([Name]) VALUES ('Андрей')
INSERT INTO [Customer] ([Name]) VALUES ('Алёна')
INSERT INTO [Customer] ([Name]) VALUES ('Алексей')
INSERT INTO [Customer] ([Name]) VALUES ('Полина')
INSERT INTO [Customer] ([Name]) VALUES ('Светлана')
INSERT INTO [Customer] ([Name]) VALUES ('Мария')
INSERT INTO [Customer] ([Name]) VALUES ('Тимофей')
GO
TRUNCATE TABLE [Product]
GO
INSERT INTO [Product] ([Name], [Price]) VALUES ('Браслет Xiaomi Mi Band 3', 1548);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Amazfit Bip', 4199);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Samsung Galaxy Watch Active', 12050);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Браслет Honor Band 4', 2249);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Samsung Galaxy Watch (46 mm)', 16250);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Samsung Gear S3 Frontier', 12860);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы CARCAM DZ09', 987);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Браслет HUAWEI Band 3 Pro', 4169);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы CARCAM S2', 2990);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Браслет Xiaomi Mi Band 2', 1250);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Garmin Instinct', 19770);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Amazfit Stratos', 10289);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Amazfit Verge', 8171);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Браслет Amazfit Cor 2', 3850);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы IWO Smart Watch IWO 7', 6500);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Amazfit Pace', 6899);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Garmin Forerunner 235', 12970);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы Apple Watch Series 3 38mm Aluminum Case with Sport Band', 16740);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Браслет GSMIN WR12', 2790);
INSERT INTO [Product] ([Name], [Price]) VALUES ('Часы KREZ Jazz', 3990);
GO
TRUNCATE TABLE [Order]
GO
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (1, '2017-03-21', NULL)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (1, '2017-04-22', 0.02)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (1, '2017-05-23', 0.1)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (1, '2018-01-04', 0.05)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (1, '2019-02-12', 0.03)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (3, '2017-03-16', NULL)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (3, '2017-03-26', 0.01)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (3, '2019-06-03', 0.03)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2015-07-25', 0.01)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2015-05-07', 0.02)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2016-01-14', 0.03)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2016-03-29', 0.04)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2017-05-03', 0.05)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2018-02-06', 0.1)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2019-01-27', 0.1)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (4, '2019-05-12', 0.15)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (6, '2019-01-20', NULL)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (6, '2019-01-29', 0.02)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (6, '2019-02-17', 0.02)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (6, '2019-03-01', 0.02)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (7, '2019-03-02', 0.03)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (7, '2019-03-11', 0.1)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (7, '2019-04-22', 0.12)
INSERT INTO [Order] ([CustomerId], [OrderDate], [Discount]) VALUES (7, '2019-06-01', 0.15)
GO
TRUNCATE TABLE [OrderLine]
GO
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (1, 11, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (1, 20, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (2, 1, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (3, 2, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (4, 3, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (5, 4, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (6, 5, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (7, 6, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (8, 7, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (9, 8, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (10, 9, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (11, 9, 2);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (12, 10, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (13, 10, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (14, 11, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (15, 11, 5);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (16, 12, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (17, 12, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (18, 13, 2);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (19, 13, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (20, 13, 4);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (21, 1, 2);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (21, 4, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (21, 9, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (22, 1, 2);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (22, 4, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (22, 9, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (23, 1, 2);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (24, 7, 2);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (24, 4, 1);
INSERT INTO [OrderLine] ([OrderId], [ProductId], [Count]) VALUES (24, 3, 2);
GO
