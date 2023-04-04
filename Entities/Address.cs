using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AddressService.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public required string Code { get; set; }

        public virtual string? Description { get; set; }

        public required string Street { get; set; }

        public required string Number { get; set; }

        public required string City { get; set; }

        public required string ZipCode { get; set; }

        public required string Country { get; set; }

        public required bool Predefined { get; set; }

        [ForeignKey("User")]
        public required int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
