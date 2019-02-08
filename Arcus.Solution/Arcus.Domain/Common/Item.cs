using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Domain.Common
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Item : EntityBase
    {
        public virtual int ItemContentId { get; set; }
        public virtual int ItemCategoryId { get; set; }
        public virtual Category Category { get; set; }
        //[ForeignKey("ItemCategoryId")]
        public virtual ItemContent ItemContent { get; set; }
        public Item()
        {
            this.ItemContent = new ItemContent();
        }
        
    }
}
