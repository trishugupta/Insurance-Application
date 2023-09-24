CREATE PROCEDURE [dbo].[usp_DeletePolicy]
(
	@PolicyCode VARCHAR(500)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM Policy WHERE PolicyCode = @PolicyCode;

	SELECT @@ROWCOUNT;
END
