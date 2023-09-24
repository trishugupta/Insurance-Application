CREATE PROCEDURE [dbo].[usp_GetPolicyByCode]  
(  
 @PolicyCode VARCHAR(200)  
)  
AS  
BEGIN  
 SET NOCOUNT ON;  
  
 SELECT 
 PolicyId AS [PolicyId],
 PolicyCode AS [PolicyCode],  
 PurchaseDate AS [PurchaseDate],   
 Fuel AS [Fuel],   
 VehicleSegment AS [VehicleSegment],   
 Premium AS [Premium],  
 bodily_injury_liability AS [bodily_injury_liability],   
 personal_injury_protection AS [personal_injury_protection],  
 property_damage_liability AS [property_damage_liability],  
 collision AS [collision],  
 comprehensive AS [comprehensive]  
 From Policy  
 WHERE PolicyCode = @PolicyCode;  
END 