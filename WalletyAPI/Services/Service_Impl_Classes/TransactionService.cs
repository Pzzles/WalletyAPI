using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;
using WalletyAPI.Repositories.Interfaces;
using WalletyAPI.Services.Service_Interfaces;
using WalletyAPI.Services.ServiceHelpers;
using WalletyAPI.Utils.Maps;
using WalletyAPI.Utils.Regexes;
using WalletyAPI.Utils.Security;

namespace WalletyAPI.Services.Service_Impl_Classes
{
    public class TransactionService : ITransactionService
    {
        private readonly IBaseRepository<Transaction> _baseRepo;
        private readonly ITransactionRepository _transactionRepo;
        public TransactionService(IBaseRepository<Transaction> baseRepo, ITransactionRepository transactionRepo)
        {
            baseRepo = _baseRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task AddAsync(TransactionDTO transactionDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionDTO?> CreateTransactionAsync(TransactionDTO transactionDTO)
        {
            Transaction transaction = new();
            try
            {
                if (transactionDTO == null) 
                    throw new ArgumentNullException(nameof(transactionDTO));
                
                if (!string.IsNullOrEmpty(transactionDTO.TransactionPin)
                    && RegexHelper.IsValid(transactionDTO.TransactionPin, RegexHelper.TransactionPINRegex)
                    && TransactionPinHelper.IsValidPin(transactionDTO.TransactionPin))

                     transaction = await _transactionRepo.CreateTransactionAsync(transactionDTO.ToEntity());
                
                return transaction.ToDTO();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the transaction: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllAsync()
        {

            try
            {

                IEnumerable<Transaction> transactionList = await _baseRepo.GetAllAsync();
                return transactionList.Select(t => t.ToDTO()).ToList();

                //List<TransactionDTO> dtos = new List<TransactionDTO>();
                //foreach (var transaction in transactionList) 
                //{
                //   dtos.Add(transaction.ToDTO());
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<TransactionDTO>();
            }

        }

        public async Task<TransactionDTO?> GetByIdAsync(object id)
        {
            try
            {
                if (id == null) throw new ArgumentNullException(nameof(id));

                Guid transactionId = ServiceHelper.ParseGuid(id);

                var transaction = await _baseRepo.GetByIdAsync(transactionId);
                return transaction.ToDTO();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the transaction: {ex.Message}");
                return null;
            }
        }

        public async Task Update(TransactionDTO entity)
        {
            try
            { 
                if(entity == null) 
                    throw new ArgumentNullException(nameof(entity));

                _baseRepo.Update(entity.ToEntity());
                await _baseRepo.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the transaction: {ex.Message}");
            }   
        }
    }
}
