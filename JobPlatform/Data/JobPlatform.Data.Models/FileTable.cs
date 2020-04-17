﻿namespace JobPlatform.Data.Common.Models
{
    using JobPlatform.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class FileTable : BaseDeletableModel<int>
    {
        public string PublicId { get; set; }

        public string Name { get; set; }

        public string FileLink { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
