using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Domain.Navigation
{
    public class Navigation
    {
        public Category Category { get; set; }
        public IList<Category> SubCategories { get; set; }
        //public Navigation()
        //{
        //    Category = new Category();
        //    SubCategories = new List<Category>();
        //}
    }
}
