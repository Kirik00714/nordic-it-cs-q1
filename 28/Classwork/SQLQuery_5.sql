CREATE OR ALTER PROCEDURE pr_CreateProduct(
    @p_category NVARCHAR (250) NOT NUll,
    @p_product NVARCHAR (250) NOT NULL
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @categoryId UNIQUEIDENTIFIER;
    DECLARE @productId UNIQUEIDENTIFIER = NEWID();
    
    
        EXEC pr_CreateCategory @p_category = @p_category,
        @p_categoryId = @categoryId OUTPUT;

    INSERT INTO Products (Id, CategoryId, [Name])
    VALUES (@productId, @categoryId,@p_product);

END;

Select * From Product;

DECLARE @productId UNIQUEIDENTIFIER;

EXEC pr_CreateProduct
@p_category = 'Mobile',
@p_product = 'Sumsung Galaxy 10',
@p_productId = @productId OUTPUT;

SELECT @productId AS ProductId;