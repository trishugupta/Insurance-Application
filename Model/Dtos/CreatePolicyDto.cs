using System.ComponentModel.DataAnnotations;

namespace Insurance.Model.Dtos
{
    public class CreatePolicyDto
    {
        [Required]
        public string PolicyCode { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? Fuel { get; set; }
        public string VehicleSegment { get; set; }
        public decimal Premium { get; set; }
        public decimal? bodily_injury_liability { get; set; }
        public decimal? personal_injury_protection { get; set; }
        public decimal? property_damage_liability { get; set; }
        public decimal? collision { get; set; }
        public decimal? comprehensive { get; set; }
    }
}
