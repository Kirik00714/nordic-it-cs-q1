CREATE OR ALTER PROCEDURE [sp_UpdateReminderItem] (
    @p_id AS UNIQUEIDENTIFIER,
    @p_status AS TINYINT,
    @p_message AS NVARCHAR(2048),
    @p_datetime AS DATETIMEOFFSET
    
)
AS 
BEGIN
    SET NOCOUNT ON;
    
    UPDATE [ReminderItem]  SET
        [StatusId] = @p_status,
        [Message] = @p_message,
        [DatetimeUtc] = @p_datetime,
        [ModifiedDatetimeUtc] = SYSDATETIMEOFFSET()
        WHERE [ReminderItem].Id = @p_id;
END
