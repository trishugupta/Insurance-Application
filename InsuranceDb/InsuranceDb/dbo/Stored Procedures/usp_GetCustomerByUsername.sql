CREATE PROCEDURE [dbo].[usp_GetCustomerByUsername]
(
	@Username VARCHAR(500)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
	CustomerId AS [CustomerId],
    UserName AS [UserName],
	FirstName AS [FirstName],
	LastName AS [LastName],
    Gender AS [Gender],
    Incomegroup AS [Incomegroup],
    Region AS [Region],
    Maritalstatus AS [Maritalstatus]
	From Customer 
	WHERE UserName = @Username
END
