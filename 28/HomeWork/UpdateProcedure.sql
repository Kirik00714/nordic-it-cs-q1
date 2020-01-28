CREATE OR ALTER PROCEDURE [sp_UpdateReminderItem] (
    @p_id AS UNIQUEIDENTIFIER,
    @p_status AS TINYINT,
    @p_message AS NVARCHAR(2048),
    @p_datetime AS DATETIMEOFFSET,
    @p_updated AS BIT OUTPUT
)
AS 
BEGIN
    SET NOCOUNT ON;
    SET @p_updated = 0;
    UPDATE [ReminderItem] RI SET
        [StatusId] = @p_status,
        [Message] = @p_message,
        [DatetimeUtc] = @p_datetime,
        [ModifiedDatetimeUtc] = SYSDATETIMEOFFSET(),
        @p_updated = 1
    WHERE RI.Id = @p_id;
END
