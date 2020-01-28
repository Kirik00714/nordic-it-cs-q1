CREATE OR ALTER PROCEDURE [sp_FindByReminderItem] (
    @p_status AS TINYINT
    @p_datetime AS DATETIMEOFFSET
)
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @datetime DATETIMEOFFSET;
    DECLARE @status TINYINT
    SELECT 
        RI.Id,
        C.Login,
        RI.StatusId,
        RI.DatetimeUtc,
        RI.Message
    FROM [ReminderItem]  RI
    JOIN [Contact] C
        ON RI.ContactId = C.Id
        WHERE @datetime =  @p_datetime AND @status = @p_status
    ORDER BY RI.DatetimeUtc 
END

