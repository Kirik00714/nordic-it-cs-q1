CREATE OR ALTER PROCEDURE [sp_AddReminderItem] (
    @p_id AS UNIQUEIDENTIFIER,
    @p_contact AS VARCHAR(64),
    @p_status AS TINYINT,
    @p_message AS NVARCHAR(2048),
    @p_datetime AS DATETIMEOFFSET
)
AS 
BEGIN
    SET NOCOUNT ON;

    DECLARE @contactId UNIQUEIDENTIFIER;
    DECLARE @now DATETIMEOFFSET = SYSDATETIMEOFFSET();

    SELECT @contactId = C.[Id] FROM [Contact] C WHERE C.[Login] = @p_contact;
    IF @contactId IS NULL 
    BEGIN
        SET @contactId = NEWID();
        INSERT INTO [Contact] ([Id], [Login]) VALUES(@contactId, @p_contact);
    END

    INSERT INTO [ReminderItem] ([Id], [ContactId], [StatusId], [DatetimeUtc], [Message], [CreatedDatetimeUtc], [ModifiedDatetimeUtc]) 
    VALUES (@p_id, @contactId, @p_status, @p_datetime, @p_message, @now, @now);
END