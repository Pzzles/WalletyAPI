namespace WalletyAPI.Models.Entities
{
    public class MerchantProfile
    {
        public string MerchantId { get; set; }
        public string BusinessId { get; set; }
        public required Business Business { get; set; }
    }
}
