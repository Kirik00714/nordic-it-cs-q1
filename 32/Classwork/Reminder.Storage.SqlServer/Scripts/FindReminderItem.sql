SELECT 
    RI.Id,
    C.Login,
    RI.StatusId,
    RI.DatetimeUtc,
    RI.Message
FROM [ReminderItem] RI
JOIN [Contact] C
  ON RI.ContactId = C.Id
WHERE RI.Id = @p_id 