using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;

namespace WalletyAPI.Utils.Maps
{
    public static partial class MappingExtensions
    {
        public static MerchantProfileDTO ToDTO(this MerchantProfile merchantProfile)
        {
            if (merchantProfile == null) return null!;
            return new MerchantProfileDTO
            {
                MerchantId = merchantProfile.MerchantId,
                Business = merchantProfile.Business.ToDTO()
            };
        }

        public static MerchantProfile ToEntity(this MerchantProfileDTO merchantProfileDto)
        {
            if (merchantProfileDto == null) return null!;
            return new MerchantProfile
            {
                MerchantId = merchantProfileDto.MerchantId,
                Business = merchantProfileDto.Business.ToEntity()
            };
        }
    }
}
