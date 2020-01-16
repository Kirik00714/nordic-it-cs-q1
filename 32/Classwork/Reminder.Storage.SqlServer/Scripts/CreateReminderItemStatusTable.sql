IF NOT EXISTS(SELECT * FROM sys.objects WHERE [name] = 'ReminderItemStatus' AND [type] = 'U')
    CREATE TABLE [ReminderItemStatus] (
        [Id] TINYINT NOT NULL,
        [Name] VARCHAR(32) NOT NULL,

        CONSTRAINT PK_ReminderItemStatus 
            PRIMARY KEY ([Id]),

        CONSTRAINT UQ_ReminderItemStatus_Name
            UNIQUE ([Name])
    );