using WalletyAPI.Models.Entities;

namespace WalletyAPI.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
    }
}
