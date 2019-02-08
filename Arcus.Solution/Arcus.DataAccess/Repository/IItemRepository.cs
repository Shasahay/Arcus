using Arcus.DataAccess.UnitOfWork;
using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
        Item GetItem(int categoryId);
        Item GetItem();
        List<Item> GetItems(int categoryId);
        List<Item> GetItems(string itemType);
        List<Item> GetItems(string categoryName, string itemType);
        List<Item> GetItems(int categoryId, string itemType);
    }
}
