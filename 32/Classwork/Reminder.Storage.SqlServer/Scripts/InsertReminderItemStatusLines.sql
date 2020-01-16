IF NOT EXISTS (SELECT * FROM [ReminderItemStatus])
    INSERT INTO [ReminderItemStatus] ([Id], [Name]) 
        VALUES  (1, 'Created'), 
                (2, 'Ready'),
                (3, 'Sent'),
                (4, 'Failed');