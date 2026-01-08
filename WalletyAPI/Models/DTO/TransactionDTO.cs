using WalletyAPI.Utils.Enums;

namespace WalletyAPI.Models.DTO
{
    public class TransactionDTO
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionPin { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public string FromUserId { get; set; } = string.Empty;
        public string ToUserId { get; set; } = string.Empty;
        public string? ReferenceCode { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
    }
}
