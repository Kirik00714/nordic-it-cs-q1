SELECT ms.Id ,
        c.Nickname,
        ms.StatusId,
        ms.[DateTime]
FROM MessageStatus AS ms
INNER JOIN Contact AS c
    ON ms.ContactId = c.Id

SELECT ms.Id ,
        c.Nickname,
        ms.StatusId,
        ms.[DateTime]
FROM MessageStatus AS ms
RIGHT JOIN Contact AS c
    ON ms.ContactId = c.Id

SELECT ms.Id ,
        c.Nickname,
        ms.StatusId,
        ms.[DateTime]
FROM MessageStatus AS ms
LEFT JOIN Contact AS c
    ON ms.ContactId = c.Id