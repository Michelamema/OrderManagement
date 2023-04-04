using AddressService.Enums;
using System.ComponentModel.DataAnnotations;

namespace AddressService.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public required string Code { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Company { get; set; }

        public required string VATCode { get; set; }

        public required UserType UserType { get; set; }

        public required string FiscalCode { get; set; }

        public virtual IList<Address> Addresses { get; set; }

    }
}
