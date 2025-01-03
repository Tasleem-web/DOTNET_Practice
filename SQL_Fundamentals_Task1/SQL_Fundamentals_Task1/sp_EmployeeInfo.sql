CREATE PROCEDURE [dbo].[sp_EmployeeInfo]
	@EmployeeName nvarchar(100) = NULL,
	@FirstName nvarchar(50) = NULL,
	@LastName nvarchar(50) = NULL,
	@CompanyName nvarchar(50),
	@Position nvarchar(50) = NULL,
	@Street nvarchar(50),
	@City nvarchar(50) = NULL,
	@State nvarchar(50) = NULL,
	@ZipCode nvarchar(50) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	IF(LTRIM(RTRIM(ISNULL(@EmployeeName, ''))) = '' AND LTRIM(RTRIM(ISNUll(@FirstName, ''))) = '' AND LTRIM(RTRIM(ISNULL(@LastName, ''))) = '')
		BEGIN
			RAISERROR('At least one of EmployeeName, FirstName, or LastName must be provided and not be empty or only spaces.', 16, 1);
			RETURN;
		END
	SET @CompanyName = LEFT(@CompanyName, 20);

	DECLARE @AddressId INT;
	INSERT INTO [dbo].[Address] (Street, City, State, ZipCode)
	VALUES (@Street, @City, @State, @ZipCode)
	SET @AddressId = SCOPE_IDENTITY();

	DECLARE @PersonId INT = NULL;
	IF(@FirstName IS NOT NULL OR @LastName IS NOT NULL)
		BEGIN
			INSERT INTO [dbo].[Person] (FirstName, LastName)
			VALUES (@FirstName, @LastName)
			SET @PersonId = SCOPE_IDENTITY()
		END

	INSERT INTO [dbo].[Employee] (AddressId, PersonId, CompanyName, Position, EmployeeName)
	VALUES(@AddressId, @PersonId, @CompanyName, @Position, @EmployeeName);

END
