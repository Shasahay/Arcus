using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Config.Common
{
    public class CategoryMapping : EntityBaseMapping<Category>
    {
        public CategoryMapping()
        {
            this.Property(x => x.Name).IsRequired();
        }
    }
}
