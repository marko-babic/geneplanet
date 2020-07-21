using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenePlanet.Models
{
    public class BreachedEmail
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Invalid format")]
        public string Email { get; set; }
    }
}
