CREATE PROCEDURE [dbo].[usp_InsertCustomer]
(
	@CustomerName VARCHAR(500),
    @FirstName VARCHAR(200),
    @LastName VARCHAR(300),
    @Gender VARCHAR(10),
    @Incomegroup VARCHAR(500),
    @Region VARCHAR(500),
    @Maritalstatus VARCHAR(500)
)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN
		    INSERT INTO Customer (UserName, FirstName, LastName, Gender, Incomegroup,Region,Maritalstatus)
            VALUES (@CustomerName, @FirstName, @LastName, @Gender, @Incomegroup,@Region,@Maritalstatus);
	END

	SELECT SCOPE_IDENTITY();
END
