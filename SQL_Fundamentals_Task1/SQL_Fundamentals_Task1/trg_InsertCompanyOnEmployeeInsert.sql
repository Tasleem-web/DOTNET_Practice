CREATE TRIGGER trg_InsertCompanyOnEmployeeInsert
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AddressId INT;
    DECLARE @Street NVARCHAR(50);
    DECLARE @City NVARCHAR(20);
    DECLARE @State NVARCHAR(50);
    DECLARE @ZipCode NVARCHAR(50);
    DECLARE @CompanyName NVARCHAR(20);

    SELECT 
        @AddressId = i.AddressId,
        @CompanyName = LEFT(i.CompanyName, 20)
    FROM 
        inserted i;

    SELECT 
        @Street = a.Street,
        @City = a.City,
        @State = a.State,
        @ZipCode = a.ZipCode
    FROM 
        [dbo].[Address] a
    WHERE 
        a.Id = @AddressId;

    DECLARE @NewAddressId INT;
    INSERT INTO [dbo].[Address] (Street, City, State, ZipCode)
    VALUES (@Street, @City, @State, @ZipCode);
    SET @NewAddressId = SCOPE_IDENTITY();

    INSERT INTO [dbo].[Company] (Name, AddressId)
    VALUES (@CompanyName, @NewAddressId);
END;