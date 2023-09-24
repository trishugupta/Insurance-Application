CREATE PROCEDURE [dbo].[usp_GetPoliciesByMonth]
(
	 @Region VARCHAR(500) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
    DATEPART(YEAR, P.PurchaseDate) AS Year,
    DATEPART(MONTH, P.PurchaseDate) AS Month,
    COUNT(*) AS PolicyCount
FROM Policy P JOIN Policy_Customer PC ON P.PolicyId = PC.PolicyId JOIN
Customer C ON PC.CustomerId = C.CustomerId
WHERE (@Region IS NULL OR C.Region = @Region OR @Region = '')
GROUP BY
    DATEPART(YEAR, P.PurchaseDate),
    DATEPART(MONTH, P.PurchaseDate)
ORDER BY
    Year, Month;
END
