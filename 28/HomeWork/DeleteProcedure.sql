CREATE OR ALTER PROCEDURE [pr_DeleteReminderItem] (
@p_id UNIQUEIDENTIFIER NOT NULL
)
AS 
BEGIN
    SET NOCOUNT ON;
    DELETE  FROM [ReminderItem] 
    WHERE
    [ReminderItem].Id=@p_id
END


