    CREATE DATABASE PostOffice;

    USE PostOffice;
    GO

    CREATE TABLE PostalSending(
       SenderName VARCHAR(50),
       ReceiverName VARCHAR(50),
       DocumetnTitle VARCHAR(50),
       NumberOfPages SMALLINT,
       SandingDate DATE,
       ExpectedReceivingDate DATE
    );

    SELECT * FROM PostalSending;

    INSERT INTO PostalSending
    VALUES ('Kirill','Vladimir','Doc.txt',10, '20191212','20191213');

    DELETE  FROM PostalSending
    WHERE SenderName = 'Kirill';
