using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Config.Common
{
    public class ItemContentMapping : EntityBaseMapping<ItemContent>
    {
        public ItemContentMapping()
        {
            this.Property(x => x.Title).IsRequired();
            this.Property(x => x.SortDescription).IsRequired();
            this.Property(x => x.Content).IsRequired();
            this.Property(x => x.SmallImage).IsOptional();
            this.Property(x => x.MediumImage).IsOptional();
            this.Property(x => x.BigImage).IsOptional();
            this.Property(x => x.IsActive).IsRequired();
            this.Property(x => x.IsDeleted).IsRequired();
           // this.HasMany(x => x.Items).WithRequired(y => y.ItemContent); // Do not know why I used it here
            
        }
    }
}
