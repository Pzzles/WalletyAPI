using System.ComponentModel.DataAnnotations.Schema;
using WalletyAPI.Utils.Enums;

namespace WalletyAPI.Models.Entities
{
    public class User : BaseUser
    {

        public TierEnum Tier { get; set; }
        public bool IsVerified { get; set; }
        public decimal PersonalBalance { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public KYCEnum? KycStatus { get; set; }
        public bool IsMerchant { get; set; }
        public List<UserGuardian> Guardians { get; set; } = new();
        public List<UserGuardian> Dependents { get; set; } = new();
        public List<Transaction> Transactions { get; set; } = new();
        public string? MerchantId { get; set; }
        public MerchantProfile? MerchantProfile { get; set; }
    }
}
