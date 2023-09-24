CREATE PROCEDURE [dbo].[usp_InsertPolicy]
(
    @PolicyCode VARCHAR(500),
	@PurchaseDate DATETIME,
	@Fuel VARCHAR(500) = NULL,
	@VECHILE_SEGMENT  VARCHAR(500),
	@Premium DECIMAL(10, 2),
	@InjuryLiability DECIMAL(10, 2) = NULL,
    @InjuryProtection DECIMAL(10, 2) = NULL,
    @ProperyLiability DECIMAL(10, 2) = NULL,
    @Collision DECIMAL(10, 2) = NULL,
    @Comprehensive DECIMAL(10, 2) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN
		    INSERT INTO Policy (PolicyCode,PurchaseDate, Fuel, VehicleSegment, Premium,bodily_injury_liability, personal_injury_protection,property_damage_liability,collision,comprehensive)
            VALUES (@PolicyCode, @PurchaseDate, @Fuel, @VECHILE_SEGMENT, @Premium,@InjuryLiability,@InjuryProtection,@ProperyLiability,@Collision,@Comprehensive);
	END

	SELECT SCOPE_IDENTITY();
END
