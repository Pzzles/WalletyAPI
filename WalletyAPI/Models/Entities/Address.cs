using Microsoft.EntityFrameworkCore;

namespace WalletyAPI.Models.Entities
{

    [Owned]
    public class Address
    {
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = "RSA";
    }
}