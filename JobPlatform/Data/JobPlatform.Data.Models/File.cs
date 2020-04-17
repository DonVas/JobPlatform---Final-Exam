namespace JobPlatform.Data.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using JobPlatform.Data.Models;

    public class File : BaseDeletableModel<int>
    {
        public string PublicId { get; set; }

        public string Name { get; set; }

        public string FileLink { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
