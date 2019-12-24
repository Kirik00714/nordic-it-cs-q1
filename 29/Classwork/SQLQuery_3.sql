SELECT * FROM [Order];
SELECT * FROM [OrderLine];

SELECT [Name],
 LEN ([Name]) AS [NameLength] 
 FROM [Product]
 WHERE LEN [Name] > 20
 ORDER BY [NameLenght];

 DECLARE @year INT = YEAR(GETUTCDATE());
 DECLARE @month INT = MONTH(GETUTCDATE());
 DECLARE @day INT = DAY(GETUTCDATE());
 SELECT 
 GETUTCDATE() AS [DateTime],
@year AS [Year],
@month AS [Month],
@day AS [Day];


SELECT * FROM OrderLine;
SELECT COUNT(*) ,COUNT (DISTINCT [COUNT])  FROM OrderLine;
SELECT COUNT(*) FROm Product;

SELECT * FROM [Order];
SELECT * FROM [Product];



SELECT COUNT (*) FROM OrderLine;

SELECT COUNT (DISTINCT [COUNT]) FROM OrderLine;

SELECT MAX ([Id]) FROM [Order];

SELECT AVG ([Discount]) FROM [Order];

SELECT MIN (OrderDate)  FROM [Order];
SELECT MAX (OrderDate)  FROM [Order];

SELECT MAX (OrderDate) FROM [Order] WHERE YEAR([OrderDate]) = 2018;

SELECT MAX( LEN ([Name])) FROM [Product];
 
SELECT [CustomerId] From [Order] WHERE Year([OrderDate]) = 2018;

SELECT 
    O.Id AS OrderId,
     C.Name AS CustomerName 
From [Order] O 
JOIN [Customer] C 
    ON O.CustomerId = C.Id 
WHERE Year([OrderDate]) = 2018;

SELECT *
FROM [Customer] C
WHERE Id IN (
    SELECT CustomerId 
    FROM [Order] 
    WHERE YEAR([OrderDate]) = 2018
);

SELECT [Id], [Name]
FROM [Product]
WHERE LEN ([Name]) IN (
    SELECT MAX(LEN ([Name])) FROM [Product]
);

SELECT [Id] ,[Discount] 
FROM [Order]
WHERE [Discount] IN (SELECT MAX([Discount]) FROM [Order]);

SELECT [Id], [OrderDate] 
FROM [Order]  
WHERE [OrderDate]  IN (
    SELECT MIN([OrderDate]) 
    FROM [Order] 
    WHERE YEAR([Orderdate]) = 2019
);

SELECT C.Name , C.Id 
FROM [Order] AS O 
JOIN [Customer] AS C ON O.CustomerId = C.Id  
WHERE [Discount] IN (
    SElECT MAX([Discount]) 
    FROM [Order] 
    WHERE YEAR([OrderDate ]) = 2016
    );

SELECT C.Name , C.Id 
FROM [Order] AS O 
JOIN [Customer] AS C ON O.CustomerId = C.Id  
WHERE [OrderDate] IN (
    SElECT MIN([OrderDate]) 
    FROM [Order] 
    WHERE YEAR([OrderDate]) = 2019
    );

SELECT O.Id AS OrderId, P.Name As OrderLineCount, OL.Count As OrderLineCount, P.Price As OrderLineproductPrice, OL.Count * P.Price AS OrderLineTotal
FROM [Order] AS O
JOIN [OrderLIne] AS OL 
    ON O.Id = OL.OrderId
    JOIN [Product] AS P
        ON P.Id = OL.ProductId
WHERE O.Id = 22;


SELECT  SUM(OL.Count * P.Price) AS Total
FROM [Order] AS O
JOIN [OrderLIne] AS OL 
    ON O.Id = OL.OrderId
    JOIN [Product] AS P
        ON P.Id = OL.ProductId
WHERE O.Id = 22;

SELECT * 
FROM [Order] AS O
JOIN [Customer] AS C ON C.Id = O.CustomerId
WHERE C.Name = 'Мария';


SELECT * FROM [Customer] ;

SELECT T.CustomerId AS CustomerId, SUM ([T.Total]) FROM(
SELECT O.CustomerId, (1 - ISNULL(O.Discount, 0)) * SUM(OL.Count * P.Price) AS Total
FROM [Order] O
JOIN [OrderLIne] AS OL 
    ON O.Id = OL.OrderId
    JOIN [Product] AS P
        ON P.Id = OL.ProductId
        JOIN [Customer] AS C
            ON C.Id =  O.CustomerId
GROUP BY  O.CustomerId,O.Discount)
GROUP BY T.CustomerId;

