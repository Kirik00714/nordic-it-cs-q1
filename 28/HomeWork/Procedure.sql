CREATE OR ALTER PROCEDURE pr_CreateContact(
    @p_ContactName NVARCHAR(256),
    @p_ContactId UNIQUEIDENTIFIER OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ContactId UNIQUEIDENTIFIER = (SELECT Id FROM Contact);
    IF @ContactId IS NULL
    BEGIN
        SET @ContactId = NEWID();
        INSERT INTO Contact (Id,Nickname)
        VALUES(@ContactId,@p_ContactName)
    END

    SET @p_ContactId = @ContactId;

END;

EXEC pr_CreateContact @p_ContactName = 'Kirill';

SELECT * FROM Contact;

CREATE OR ALTER PROCEDURE pr_CreateStatus(
    @p_Status NVARCHAR(256),
    @p_StatusId UNIQUEIDENTIFIER OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @StatusId UNIQUEIDENTIFIER = (SELECT Id FROM [Status]);
    IF @StatusId IS NULL
    BEGIN
        SET @StatusId = NEWID();
        INSERT INTO [Status] (Id,Status)
        VALUES(@StatusId,@p_Status)
    END

    SET @p_StatusId = @StatusId;

END;

EXEC pr_CreateStatus @p_Status = 'Create';

SELECT * FROM [Status];

CREATE OR ALTER PROCEDURE pr_CreateMessageStatus(
    @p_ContactName NVARCHAR (250),
    @p_Status NVARCHAR (250),
    @p_Message VARCHAR(2048)
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ContactId UNIQUEIDENTIFIER;
    DECLARE @StatusId UNIQUEIDENTIFIER;
    DECLARE @MessageStatusId UNIQUEIDENTIFIER = NEWID();
    DECLARE @DateTime DATETIME2 = GETUTCDATE();
    DECLARE @Message VARCHAR(2048) = @p_Message;
    
    
        EXEC pr_CreateContact @p_ContactName = @p_ContactName,
        @p_ContactId = @ContactId OUTPUT;
        EXEC pr_CreateStatus @p_Status = @p_Status,
        @p_StatusId = @StatusId OUTPUT;

    INSERT INTO MessageStatus (Id, ContactId,StatusId,[Message], [DateTime])
    VALUES (@MessageStatusId, @ContactId,@StatusId,@Message,@DateTime);

END;

EXEC pr_CreateMessageStatus
@p_ContactName = 'Kirill',
@p_Status = 'Create',
@p_Message = 'Some text';


SELECT * FROM MessageStatus;