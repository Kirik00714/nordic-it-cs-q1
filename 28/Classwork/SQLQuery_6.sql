SELECT p.Id As Id, p.Name AS ProductName, c.Name AS Category FROM Products AS p
INNER Join Category AS c
    ON p.CategoryId = c.Id;

SELECT p.Id As Id, p.Name AS ProductName, c.Name AS Category FROM Products AS p
LEFT Join Category AS c
    ON p.CategoryId = c.Id;

SELECT p.Id As Id, p.Name AS ProductName, c.Name AS Category FROM Products AS p
RIGHT Join Category AS c
    ON p.CategoryId = c.Id