using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;

namespace WalletyAPI.Utils.Maps
{
    public static partial class MappingExtensions
    {
        public static UserDTO ToDTO(this User user)
        {
            if (user == null) return null!;
            return new UserDTO
            {
                UserId = user.UserId.ToString(),
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Role = user.Role,
                Tier = user.Tier,
                IsVerified = user.IsVerified,
                PersonalBalance = user.PersonalBalance,
                KycStatus = user.KycStatus,
                IsMerchant = user.IsMerchant,
                MerchantProfile = user.MerchantProfile?.ToDTO()
            };
        }

        public static User ToEntity(this UserDTO userDto)
        {
            if (userDto == null) return null!;
            return new User
            {
                //UserId = Guid.Parse(userDto.UserId),
                UserId = Guid.Parse(userDto.UserId),
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                ProfilePictureUrl = userDto.ProfilePictureUrl,
                Role = userDto.Role,
                Tier = userDto.Tier,
                IsVerified = userDto.IsVerified,
                PersonalBalance = userDto.PersonalBalance,
                KycStatus = userDto.KycStatus,
                IsMerchant = userDto.IsMerchant,
                PasswordHash = string.Empty, // PasswordHash is not mapped from DTO
                PasswordSalt = string.Empty, // PasswordSalt is not mapped from DTO
                // Note: MerchantProfile mapping is not included here to avoid circular references.
            };
        }
    }
}
