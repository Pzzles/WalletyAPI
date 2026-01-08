using WalletyAPI.Utils.Enums;

namespace WalletyAPI.Models.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;

        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }

        public RoleEnum Role { get; set; }
        public TierEnum Tier { get; set; }
        public bool IsVerified { get; set; }
        public decimal PersonalBalance { get; set; }
        public KYCEnum? KycStatus { get; set; }

        // Merchant Logic
        public bool IsMerchant { get; set; }
        public MerchantProfileDTO? MerchantProfile { get; set; }
    }
}
