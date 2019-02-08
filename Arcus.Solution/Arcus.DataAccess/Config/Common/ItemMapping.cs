using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Config.Common
{
    public class ItemMapping : EntityBaseMapping<Item>
    {
        public ItemMapping()
        {
            this.Property(x => x.ItemContentId);
            this.HasRequired(x => x.Category).WithMany(y => y.Items).HasForeignKey(key => key.ItemCategoryId);
            this.HasRequired(x => x.ItemContent).WithMany(y => y.Items).HasForeignKey(key => key.ItemContentId);
        }
    }
}
