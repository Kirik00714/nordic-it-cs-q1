IF NOT EXISTS(SELECT * FROM sys.objects WHERE [name] = 'ReminderItem' AND [type] = 'U')
    CREATE TABLE [ReminderItem] (
        [Id] UNIQUEIDENTIFIER NOT NULL,
        [ContactId] UNIQUEIDENTIFIER NOT NULL,
        [StatusId] TINYINT NOT NULL,
        [DatetimeUtc] DATETIMEOFFSET NOT NULL,
        [Message] NVARCHAR(2048),
        [CreatedDatetimeUtc] DATETIMEOFFSET NOT NULL,
        [ModifiedDatetimeUtc] DATETIMEOFFSET NOT NULL,

        CONSTRAINT PK_ReminderItem 
            PRIMARY KEY ([Id]),

        CONSTRAINT FK_ReminderItem_Contact
            FOREIGN KEY ([ContactId]) REFERENCES Contact([Id])
                ON UPDATE CASCADE
                ON DELETE CASCADE,

        CONSTRAINT FK_ReminderItem_ReminderItemStatus
            FOREIGN KEY ([StatusId]) REFERENCES ReminderItemStatus([Id])
                ON UPDATE CASCADE
                ON DELETE CASCADE
    );
