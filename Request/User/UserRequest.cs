using AddressService.Enums;
using AddressService.Request.Address;

namespace AddressService.Request.User
{
    public class UserRequest
    {

        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Company { get; set; }

        public string? VATCode { get; set; }

        public UserType UserType { get; set; }

        public string? FiscalCode { get; set; }

        public List<AddressRequest> Addresses { get; set; }
    }
}
