CREATE OR ALTER PROCEDURE pr_CreateCategory(
    @p_category NVARCHAR(250) NOT NULL,
    @p_categoryId UNIQUEIDENTIFIER OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @categoryId UNIQUEIDENTIFIER = [k_balaev_schema].fn_FindCategory(p_category);

    IF @categoryId IS NULL
    BEGIN
    SET @categoryId = NEWID();
        INSERT INTO Category(Id,[Name])
        VALUES(NEWID(), @p_category);
        
    END

    @p_categoryId = @p_categoryId;
END;
GO

EXEC [k_balaev_schema].pr_CreateCategory @p_category = 'Video Player';