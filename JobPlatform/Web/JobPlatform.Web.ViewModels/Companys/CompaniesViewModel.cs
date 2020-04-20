using System;
using System.Collections.Generic;
using System.Text;

namespace JobPlatform.Web.ViewModels.Company
{
    public class CompaniesViewModel
    {
        public ICollection<CompanySimpleViewModel> Companies { get; set; }
    }
}
