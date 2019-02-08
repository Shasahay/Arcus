using Arcus.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultDBContext _context;
        public IItemRepository Items { get; set; }
        public ICategoryRepository Categories { get; set; }
        public INavigationRepository Navigations { get; set; }
        public IItemContentRepository ItemContents { get; set; }
        public UnitOfWork( DefaultDBContext context)
        {
            _context = context;
            Items = new ItemRepository(_context);
            Categories = new CategoryRepository(_context);
            Navigations = new NavigationRepository(_context);
            ItemContents = new ItemContentRepository(_context);
        }

        public int SaveJob()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
