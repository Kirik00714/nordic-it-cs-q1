CREATE TABLE Category(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED (Id)
);


INSERT INTO Category (Id,[Name])
VALUES (NEWID(), 'Mobile Phone');

INSERT INTO Category (Id,[Name])
VALUES (NEWID(), 'Laptop Device');

INSERT INTO Category (Id,[Name])
VALUES (NEWID(), 'Super Laptop');


INSERT INTO Category (Id,[Name])
VALUES ('422b42d4-a27a-45c3-a2ec-1bdd48ff7c77', 'Tablet');
        

INSERT INTO Category (Id,[Name])
VALUES (NEWID() , 'Computer'),
        (NEWID(), 'Laptop'),
        (NEWID(), 'MP3 Player');



-- Суммирование строк
SELECT COUNT(*) FROM Category;

SELECT * FROM Category;



UPDATE Category
SET [Name] = 'Tablet'
WHERE Id = '422b42d4-a27a-45c3-a2ec-1bdd48ff7c77';


CREATE UNIQUE INDEX UX_Table_Name 
ON Category ([Name]);

DELETE FROM Category
WHERE [Name] = 'Tablet';

TRUNCATE TABLE Category;

SELECT  * FROM Category
ORDER BY [Name] ASC
OFFSET  2 ROW 
FETCH NEXT 1 ROW ONLY;

SELECT * FROM Category
WHERE [Name] LIKE '%Laptop%' COLLATE Latin1_General_CS_AS_KS_WS;

-- НАчинается на 'Laptop'
SELECT * FROM Category
WHERE [Name] LIKE 'Laptop%';

-- Заканчивается на 'Laptop'
SELECT * FROM Category
WHERE [Name] LIKE '%Laptop';

DROP TABLE Category;