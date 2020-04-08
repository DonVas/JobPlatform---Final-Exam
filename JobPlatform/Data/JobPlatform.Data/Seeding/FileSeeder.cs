namespace JobPlatform.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using JobPlatform.Data.Common.Models;

    internal class FileSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FileTables.Any())
            {
                return;
            }

            //await dbContext.FileTables.AddAsync(new FileTable { Name = "Default", UploadedFile =  } );
        }
    }
}
