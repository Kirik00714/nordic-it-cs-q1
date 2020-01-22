CREATE OR ALTER PROCEDURE [pr_DeleteContact] (
@p_id UNIQUEIDENTIFIER NOT NULL
)
AS 
BEGIN
    SET NOCOUNT ON;
    DELETE  FROM [Contact] 
    WHERE
    [Contact].Id=@p_id
END


CREATE OR ALTER PROCEDURE [pr_DeleteStatus] (
@p_id UNIQUEIDENTIFIER NOT NULL
)
AS 
BEGIN
    SET NOCOUNT ON;
    DELETE  FROM [Status] 
    WHERE
    [Status].Id=@p_id
END

CREATE OR ALTER PROCEDURE [pr_DeleteMessageStatus] (
@p_id UNIQUEIDENTIFIER NOT NULL
)
AS 
BEGIN
    SET NOCOUNT ON;
    DELETE  FROM [MessageStatus] 
    WHERE
    [MessageStatus].Id=@p_id
END