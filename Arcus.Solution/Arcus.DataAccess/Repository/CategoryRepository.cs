using Arcus.DataAccess.UnitOfWork;
using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public DefaultDBContext DefaultDBContext {get {return Context as DefaultDBContext;}}

        
        public CategoryRepository(DefaultDBContext context) : base(context)
        {

        }

        public Category GetCategory()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
