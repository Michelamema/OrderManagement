using AddressService.Response.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressService.Response.Address
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public bool Predefined { get; set; }
        public UserResponse User { get; set; }
    }
}
