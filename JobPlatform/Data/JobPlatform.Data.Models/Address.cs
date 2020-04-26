namespace JobPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        public Address()
        {
        }

        public Address(string city, string region, string postCode, string streetAddress, string country)
        {
            this.City = city;
            this.Region = region;
            this.PostCode = postCode;
            this.StreetAddress = streetAddress;
            this.Country = country;
        }

        [Required]
        public string City { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Formatted => this.Country + ", " + this.Region + ", " + this.City + ", " + this.StreetAddress;
    }
}
