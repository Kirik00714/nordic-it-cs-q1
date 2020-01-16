SELECT 
    RI.Id,
    C.Login,
    RI.StatusId,
    RI.DatetimeUtc,
    RI.Message
FROM [ReminderItem] RI
JOIN [Contact] C
  ON RI.ContactId = C.Id
{predicate}
ORDER BY RI.DatetimeUtc 
OFFSET {offset} ROWS
FETCH NEXT {limit} ROWS ONLY;