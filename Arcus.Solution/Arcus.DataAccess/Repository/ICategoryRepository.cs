using Arcus.DataAccess.UnitOfWork;
using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategory();
        Category GetCategory(int id);
    }
}
