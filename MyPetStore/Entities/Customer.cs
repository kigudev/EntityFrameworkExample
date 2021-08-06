using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPetStore.Entities
{
    public class Customer
    {
#nullable enable
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? Phone { get; set; }
        [MaxLength(200)]
        public string? Email { get; set; }
        public string? StateOrProvinceAbbr { get; set; }
        public string? Country { get; set; }
#nullable disable
        public int? PostalCode { get; set; }

        // este se le llama propiedad de navegación
        public ICollection<Order> Orders { get; set; }
    }
}