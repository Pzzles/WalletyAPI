using WalletyAPI.Data;
using WalletyAPI.Models.Entities;
using WalletyAPI.Repositories.Interfaces;

namespace WalletyAPI.Repositories.Impl_Classes
{
    public class TransactionImpl : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            return transaction;
        }
    }
}
