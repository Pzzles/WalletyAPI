using System.ComponentModel.DataAnnotations.Schema;

namespace WalletyAPI.Models.Entities
{
    public class Business
    {
        private Business() { }
        public Business(Address registeredAddress)
        {
            RegisteredAddress = registeredAddress;
        }

        public Guid BusinessId { get; set; } = Guid.NewGuid();
        public string BusinessLegalName { get; set; } //Legal Name
        public string BusinessTradingName { get; set; } // Trading As
        public required string RegistrationNumber { get; set; }
        public required string TaxNumber { get; set; }
        public string? SupportEmail { get; set; }
        public string? SupportPhoneNumber { get; set; }

        public Address RegisteredAddress { get; private set; }
    }
}
