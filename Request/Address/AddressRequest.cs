
namespace AddressService.Request.Address
{
    public class AddressRequest
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
        public int UserId { get; set; }
    }
}
