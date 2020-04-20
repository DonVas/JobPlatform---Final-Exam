namespace JobPlatform.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Models;

    public class File : BaseDeletableModel<int>
    {
        public string PublicId { get; set; }

        [Required]
        public string Name { get; set; }

        [Url]
        public string FileLink { get; set; }

        [Required]
        public virtual string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
