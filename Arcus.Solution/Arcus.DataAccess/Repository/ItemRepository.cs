using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcus.Domain.Common;
using Arcus.DataAccess.UnitOfWork;
namespace Arcus.DataAccess.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public DefaultDBContext DefaultDbContext { get { return Context as DefaultDBContext; } }
        
        public ItemRepository(DefaultDBContext context) : base(context)
        {

        }

        public Item GetItem(int categoryId)
        {
            return DefaultDbContext.Items.Find(categoryId);
        }
        public List<Item> GetItems(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Item GetItem()
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItems(string itemType)
        {
            var varItem = DefaultDbContext.Items.Join
                (DefaultDbContext.ItemContents.Where( x=> x.ItemType.Equals(itemType) && x.IsActive == true), item => item.ItemContentId, itemContent => itemContent.Id, (item, itemContent) => new { item, itemContent });
            List<Item> items = new List<Item>();
            foreach (var itm in varItem)
            {
                var item = new Item();
                item = itm.item;
                item.ItemContent = itm.itemContent;
                items.Add(item);
            }
            return items;
        }

        public List<Item> GetItems(string categoryName, string itemType)
        {
            var varItem = DefaultDbContext.Categories.Where(c => c.Name.Equals(categoryName)).Join
                (DefaultDbContext.Items, cat => cat.Id, item => item.ItemCategoryId, (cat, item) => new { cat, item }).Join
               (DefaultDbContext.ItemContents.Where(x => x.IsActive == true && x.ItemType.Equals(itemType)), itm => itm.item.ItemContentId, itemContent => itemContent.Id, (itm, itemContent) => new { itm, itemContent });
            List<Item> items = new List<Item>();
            foreach (var itm in varItem)
            {
                var item = new Item();
                item = itm.itm.item;
                item.ItemContent = itm.itemContent;
                item.Category = itm.itm.cat;
                items.Add(item);
            }
            return items;
        }

        public List<Item> GetItems(int categoryId, string itemType)
        {
            throw new NotImplementedException();
        }
    }
}
