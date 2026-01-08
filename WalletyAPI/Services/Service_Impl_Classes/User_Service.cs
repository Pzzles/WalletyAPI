using System;
using System.Text.RegularExpressions;
using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;
using WalletyAPI.Repositories.Interfaces;
using WalletyAPI.Services.Service_Interfaces;
using WalletyAPI.Services.ServiceHelpers;
using WalletyAPI.Utils.Enums;
using WalletyAPI.Utils.Maps;
using WalletyAPI.Utils.Regexes;

namespace WalletyAPI.Services.Service_Impl_Classes
{
    public class User_Service : IUserService
    {
        private readonly IBaseRepository<User> _baseRepo;
        private readonly IUserRepository _userRepo;

        public User_Service(IBaseRepository<User> baseRepo, IUserRepository userRepo)
        {
            baseRepo = _baseRepo;
            _userRepo = userRepo;
        }

        public async Task AddAsync(UserDTO userDTO)
        {
            try
            {
                if (userDTO == null) throw new ArgumentNullException(nameof(userDTO));
                
                await _baseRepo.AddAsync(userDTO.ToEntity());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the user: {ex.Message}");
                return;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            
            try
            {
                var users = await _baseRepo.GetAllAsync();
                return users.Select(u => u.ToDTO()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<UserDTO>();
            }

        }

        public async Task<UserDTO?> GetByIdAsync(object id)
        {
            try
            {
                Guid guidId = ServiceHelper.ParseGuid(id);

                var user = await _baseRepo.GetByIdAsync(guidId);
                return user?.ToDTO();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the user: {ex.Message}");
                return null;
            }
        }



        public void Remove(UserDTO userDTO) 
        {
            try
            {
                if (userDTO == null) throw new ArgumentNullException(nameof(userDTO));

                _baseRepo.Remove(userDTO.ToEntity());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing the user: {ex.Message}");
            }
        }

        public void Update(UserDTO userDTO)
        {
            try
            {
                if (userDTO == null) throw new ArgumentNullException(nameof(userDTO));

                _baseRepo.Update(userDTO.ToEntity());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the user: {ex.Message}");
            }
        }

        public async Task<UserDTO?> GetByField(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return null;


            try
            {
                string fieldStr = field.Trim();

                if (RegexHelper.IsValid(fieldStr, RegexHelper.EmailRegex))
                {
                    var user = await _userRepo.GetByEmailAsync(fieldStr);
                    return user?.ToDTO();
                }

                if (RegexHelper.IsValid(fieldStr, RegexHelper.PhoneNumberRegex))
                {
                    var user = await _userRepo.GetByPhoneNumberAsync(fieldStr);
                    return user?.ToDTO();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the user: {ex.Message}");
            }
            return null;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _baseRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
            }
        }

        IQueryable<UserDTO> IBaseRepository<UserDTO>.Query()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpgradeToMerchant(UserDTO userDto, BusinessDTO businessDto)
        { 
            /// return actual dedicated messages for each failure case later///
            if (userDto == null) return false;
            if (businessDto == null) return false;
            if (!userDto.IsVerified) return false;
            if (userDto.IsMerchant) return false;

            try
            {
                var user = await _baseRepo.GetByIdAsync(userDto.UserId);
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                user.IsMerchant = true;
                user.Role = RoleEnum.Merchant;
                user.UpdatedDate = DateTime.UtcNow;

                var merchantProfile = new MerchantProfile
                {
                    MerchantId = userDto.UserId,
                    Business = businessDto.ToEntity()

                };
                //Business = new Business
                //{
                //    BusinessId = Guid.NewGuid(),
                //    BusinessLegalName = business.BusinessLegalName,
                //    BusinessTradingName = business.BusinessTradingName,
                //    RegistrationNumber = business.RegistrationNumber,
                //    TaxNumber = business.TaxNumber,
                //    SupportEmail = business.SupportEmail,
                //    SupportPhoneNumber = business.SupportPhoneNumber,
                //    RegisteredAddress = new Address
                //    {
                //        Street = business.RegisteredAddress.Street,
                //        Building = business.RegisteredAddress.Building,
                //        City = business.RegisteredAddress.City,
                //        Province = business.RegisteredAddress.Province,
                //        PostalCode = business.RegisteredAddress.PostalCode,
                //        Country = business.RegisteredAddress.Country
                //    }

                //}


                user.MerchantProfile = merchantProfile;
                user.MerchantId = merchantProfile.MerchantId;

                _baseRepo.Update(user);
                await _baseRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while upgrading the user to merchant: {ex.Message}");
            }

            return false;
        }
    }
}
