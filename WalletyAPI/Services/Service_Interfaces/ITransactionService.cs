using WalletyAPI.Models.DTO;
using WalletyAPI.Repositories.Interfaces;

namespace WalletyAPI.Services.Service_Interfaces
{
    public interface ITransactionService : IBaseRepository<TransactionDTO>
    {
        public Task<TransactionDTO> CreateTransactionAsync(TransactionDTO transactionDTO);
    }
}
