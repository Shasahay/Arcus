using Arcus.Domain.Common;
using Arcus.Domain.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Web.Infra.ViewModels
{
    public class HeaderViewModel
    {
        public string SiteTitle { get; set; }
        public int CurrentCategoryId { get; set; }
        public string CurrentCategoryName { get; set; }
        public List<Category> Categories { get; set; }
        public List<Navigation> Navigations { get; set; }
        public HeaderViewModel()
        {
            this.Categories = new List<Category>();
            this.Navigations = new List<Navigation>();
        }

    }
}
