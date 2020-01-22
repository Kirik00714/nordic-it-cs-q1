CREATE OR ALTER PROCEDURE [sp_FindByIdContact] (
    @p_id AS UNIQUEIDENTIFIER
)
AS 
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Contact.Id,
        Contact.Nickname
    FROM [Contact] 
    WHERE Contact.Id = @p_id 
END

EXEC [sp_FindByIdContact] @p_id = d5120178-4b71-4fa8-869f-af0118b137b1;

CREATE OR ALTER PROCEDURE [sp_FindByIdStatus] (
    @p_id AS UNIQUEIDENTIFIER
)
AS 
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        [Status].Id,
        [Status].Nickname
    FROM [Status] 
    WHERE [Status].Id = @p_id 
END

CREATE OR ALTER PROCEDURE [sp_FindByIdMessageStatus] (
    @p_id AS UNIQUEIDENTIFIER
)
AS 
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MessageStatus.Id,
    MessageStatus.ContactId,
    MessageStatus.StatusId,
    MessageStatus.[Message],
    MessageStatus.[DateTime]
    FROM [MessageStatus] 
    WHERE [MessageStatus].Id = @p_id 
END