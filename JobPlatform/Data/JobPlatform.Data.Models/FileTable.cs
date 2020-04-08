namespace JobPlatform.Data.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class FileTable : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public byte[] UploadedFile { get; set; }
    }
}
