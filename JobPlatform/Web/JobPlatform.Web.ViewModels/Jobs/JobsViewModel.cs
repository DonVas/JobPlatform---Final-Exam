using System;
using System.Collections.Generic;
using System.Text;
using JobPlatform.Web.ViewModels.Jobs;

namespace JobPlatform.Web.ViewModels.Jobs
{
    public class JobsViewModel
    {
        public  ICollection<JobViewModel> Jobs { get; set; }
    }
}
