using Microsoft.EntityFrameworkCore;
using WalletyAPI.Data;
using WalletyAPI.Models.Entities;
using WalletyAPI.Repositories.Interfaces;
using WalletyAPI.Utils.Regexes;


namespace WalletyAPI.Repositories.Impl_Classes
{
    public class UserImpl : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserImpl(ApplicationDbContext contnext)
        {
            _context = contnext;    
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;

            return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(phoneNumber));
        }
    }
}
