namespace WalletyAPI.Models.DTO
{
    public class BusinessDTO
    {
        public string BusinessLegalName { get; set; } = null!;
        public string BusinessTradingName { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public string TaxNumber { get; set; } = null!;
        public string? SupportEmail { get; set; }
        public string? SupportPhoneNumber { get; set; }
        public AddressDTO RegisteredAddress { get; set; } = null!;
    }
}
