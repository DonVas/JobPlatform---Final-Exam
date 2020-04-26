namespace JobPlatform.Web.ViewModels.Address
{
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class AddressInputModel : IMapFrom<Address>
    {
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(500)]
        public string StreetAddress { get; set; }
    }
}
