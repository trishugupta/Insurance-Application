CREATE PROCEDURE [dbo].[usp_UpdatePolicy]
(
    @PolicyCode VARCHAR(500),
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
		    UPDATE Policy SET Fuel = @Fuel, VehicleSegment = @VECHILE_SEGMENT, 
			Premium = @Premium,bodily_injury_liability = @InjuryLiability, 
			personal_injury_protection = @InjuryProtection,property_damage_liability = @ProperyLiability,
			collision = @Collision,comprehensive =@Comprehensive
			Where PolicyCode = @PolicyCode
	END

	SELECT @@ROWCOUNT;
END
