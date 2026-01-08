using WalletyAPI.Models.DTO;
using WalletyAPI.Models.Entities;

namespace WalletyAPI.Utils.Maps
{
    public static partial class MappingExtensions
    {
        public static AddressDTO ToDTO(this Address address)
        {
            if (address == null) return null!;
            return new AddressDTO
            {
                Street = address.Street,
                City = address.City,
                Building = address.Building,
                Province = address.Province,
                PostalCode = address.PostalCode,
                Country = address.Country
            };
        }

        public static Address ToEntity(this AddressDTO addressDto)
        {
            if (addressDto == null) return null!;
            return new Address
            {
                Street = addressDto.Street,
                City = addressDto.City,
                Building = addressDto.Building,
                Province = addressDto.Province,
                PostalCode = addressDto.PostalCode,
                Country = addressDto.Country
            };
        }
    }
}
