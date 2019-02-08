using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Domain.Common
{
    public class CategoryHierarchy : EntityBase
    {
        public int categoryID { get; set; }
        public int? ChildCategoryID { get; set; }
    }
}
