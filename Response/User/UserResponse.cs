using AddressService.Enums;
using AddressService.Response.Address;

namespace AddressService.Response.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public string? VATCode { get; set; }
        public UserType UserType { get; set; }
        public string? FiscalCode { get; set; }
        public List<AddressResponse>? Addresses { get; set; }
    }
}
