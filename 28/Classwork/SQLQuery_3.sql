-- Guid fn_FindCategory(string)
CREATE OR ALTER FUNCTION fn_FindCategory(
    @p_category NVARCHAR (250) NOT NULL
)
RETURNS UNIQUEIDENTIFIER
BEGIN
    DECLARE @categoryId UNIQUEIDENTIFIER;

    SELECT @categoryId = Id 
    FROM Category 
    WHERE [Name] = @p_category;

    IF @categoryId IS NULL
    BEGIN
        SELECT TOP 1
            @categoryId = Id 
        FROM Category 
        WHERE [Name] LIKE @p_category + '%'
        ORDER BY [Name];
    END

    RETURN @categoryId
END;
GO

SELECT * FROM Category;
SELECT [k_balaev_schema].fn_FindCategory('Computer');
SELECT [k_balaev_schema].fn_FindCategory('Com');
SELECT [k_balaev_schema].fn_FindCategory('NOT  FOUND');