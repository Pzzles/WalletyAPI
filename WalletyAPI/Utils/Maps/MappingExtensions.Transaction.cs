using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;

namespace WalletyAPI.Utils.Maps
{
    public static partial class MappingExtensions
    {
        public static TransactionDTO ToDTO(this Transaction transaction)
        {
            if (transaction == null) return null!;
            return new TransactionDTO
            {
                Amount = transaction.Amount,
                FromUserId = transaction.SenderId.ToString(),
                ToUserId = transaction.RecipientId.ToString(),
                TransactionDate = transaction.TransactionDate,
                TransactionId = transaction.TransactionId.ToString(),
                TransactionStatus = transaction.TransactionStatus,
                TransactionType = transaction.TransactionType,
                ReferenceCode = transaction.ReferenceCode

            };
        }

        public static Transaction ToEntity(this TransactionDTO transactionDto)
        {
            if (transactionDto == null) return null!;
            return new Transaction
            {
                Amount = transactionDto.Amount,
                SenderId = Guid.Parse(transactionDto.FromUserId),
                RecipientId = Guid.Parse(transactionDto.ToUserId),
                TransactionDate = transactionDto.TransactionDate,
                TransactionStatus = transactionDto.TransactionStatus,
                TransactionType = transactionDto.TransactionType,
                ReferenceCode = transactionDto.ReferenceCode

            };
        }
    }
}
