using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;

namespace WalletyAPI.Utils.Maps
{
    public static partial class MappingExtensions
    {
        public static BusinessDTO ToDTO(this Business business)
        {
            if (business == null) return null!;
            return new BusinessDTO
            {
                BusinessLegalName = business.BusinessLegalName,
                BusinessTradingName = business.BusinessTradingName,
                RegistrationNumber = business.RegistrationNumber,
                TaxNumber = business.TaxNumber,
                SupportEmail = business.SupportEmail,
                SupportPhoneNumber = business.SupportPhoneNumber,
                RegisteredAddress = business.RegisteredAddress.ToDTO()
            };
        }

        public static Business ToEntity(this BusinessDTO businessDto)
        {
            if (businessDto == null) return null!;
            return new Business
            {
                BusinessLegalName = businessDto.BusinessLegalName,
                BusinessTradingName = businessDto.BusinessTradingName,
                RegistrationNumber = businessDto.RegistrationNumber,
                TaxNumber = businessDto.TaxNumber,
                SupportEmail = businessDto.SupportEmail,
                SupportPhoneNumber = businessDto.SupportPhoneNumber,
                RegisteredAddress = businessDto.RegisteredAddress.ToEntity()
            };
        }
    }
}
