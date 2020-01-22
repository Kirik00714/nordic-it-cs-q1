CREATE OR ALTER PROCEDURE [sp_UpdateContact] (
    @p_id AS UNIQUEIDENTIFIER,
    @p_nickname AS NVARCHAR(2048),
    @p_updated AS BIT OUTPUT
)
AS 
BEGIN
    SET NOCOUNT ON;
    SET @p_updated = 0;
    UPDATE [Contact] C SET
        [Nickname] = @p_nickname,
        @p_updated = 1
    WHERE C.Id = @p_id;
END

CREATE OR ALTER PROCEDURE [sp_UpdateStatus] (
    @p_id AS UNIQUEIDENTIFIER,
    @p_status AS NVARCHAR(128),
    @p_updated AS BIT OUTPUT
)
AS 
BEGIN
    SET NOCOUNT ON;
    SET @p_updated = 0;
    UPDATE [Status] S SET
        [StatusId] = @p_status,
        @p_updated = 1
    WHERE S.Id = @p_id;
END

CREATE OR ALTER PROCEDURE [sp_UpdateMessageStatus] (
    @p_id AS UNIQUEIDENTIFIER,
    @p_status AS NVARCHAR(128),
    @p_message AS NVARCHAR(2048),
    @p_datetime AS DATETIMEOFFSET,
    @p_updated AS BIT OUTPUT
)
AS 
BEGIN
    SET NOCOUNT ON;
    SET @p_updated = 0;
    UPDATE [MessageStatus] MS SET
        [StatusId] = @p_status,
        [Message] = @p_message,
        [DatetimeUtc] = @p_datetime,
        [ModifiedDatetimeUtc] = SYSDATETIMEOFFSET(),
        @p_updated = 1
    WHERE MS.Id = @p_id;
END