using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Domain.Common
{
    public class ItemContent : EntityBase
    {
        public ItemContent()
        {
            //this.Items = new List<Item>();
            IsActive = true;
            IsDeleted = false;
        }
        public string Title { get; set; }
        public string SortDescription { get; set; }
        public string Content { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string BigImage { get; set; }
        public string ItemType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual IList<Item> Items { get; set; }
        
    }
}
