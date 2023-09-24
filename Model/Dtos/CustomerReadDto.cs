﻿using System.ComponentModel.DataAnnotations;

namespace Insurance.Model.Dtos
{
    public class CustomerReadDto
    {
        [Required]
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Gender { get; set; }
        public string Incomegroup { get; set; }
        public string Region { get; set; }
        public string Maritalstatus { get; set; }
    }
}
