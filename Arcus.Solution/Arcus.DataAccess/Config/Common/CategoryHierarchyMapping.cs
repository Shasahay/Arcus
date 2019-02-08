using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Config.Common
{
    public class CategoryHierarchyMapping : EntityBaseMapping<CategoryHierarchy>
    {
        public CategoryHierarchyMapping()
        {
            this.Property(x => x.ChildCategoryID).IsOptional();
        }
    }
}
