using WalletyAPI.Utils.Enums;

namespace WalletyAPI.Models.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionPin { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public User Recipient { get; set; } = null!;
        public User Sender { get; set; } = null!;
        public TransactionStatusEnum TransactionStatus { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public string? ReferenceCode { get; set; }
    }
}
