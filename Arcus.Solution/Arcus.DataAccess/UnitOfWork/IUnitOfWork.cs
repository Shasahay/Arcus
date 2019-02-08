using Arcus.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Items { get; }
        ICategoryRepository Categories { get; }
        INavigationRepository Navigations { get; }
        IItemContentRepository ItemContents { get; }
        int SaveJob();
    }
}
