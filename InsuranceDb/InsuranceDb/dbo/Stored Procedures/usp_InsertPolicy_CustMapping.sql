CREATE  PROCEDURE [dbo].[usp_InsertPolicy_CustMapping]
(
	@PolicyId BIGINT,
    @CustomerId BIGINT,
	@AffectedRows INT OUTPUT
	
	)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN
		    INSERT INTO Policy_Customer (PolicyId, CustomerId)
            VALUES (@PolicyId, @CustomerId);
	END

    
	SET @AffectedRows = @@ROWCOUNT;

	
END
