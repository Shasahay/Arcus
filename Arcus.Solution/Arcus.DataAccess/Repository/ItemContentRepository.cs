using Arcus.DataAccess.UnitOfWork;
using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Repository
{
    public class ItemContentRepository : Repository<ItemContent>, IItemContentRepository
    {
        public DefaultDBContext DefaultDBContext { get { return Context as DefaultDBContext; } }

        public ItemContentRepository(DefaultDBContext context) : base(context)
        {
           
        }
    }
}
 